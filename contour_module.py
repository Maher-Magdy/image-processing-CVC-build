import cv2
import numpy as np
import matplotlib.pyplot as plt
# import matplotlib.image as mpimg
# import imutils
# from sklearn.metrics import pairwise
import math

#get binary image form colored image used only in testing
def get_binary_image(image_path,threshold=50):
    # read binary image
    image = cv2.imread(image_path, 1)
    # apply threshold
    image_gray = cv2.cvtColor(image, cv2.COLOR_BGR2GRAY)
    _, image_binary = cv2.threshold(image_gray, threshold, 255, cv2.THRESH_BINARY)
    return image_binary

# calculate the contour with max area
def get_contour_max_area(contours,return_area=False):
    max_area=0
    max_contour=0
    cnt=0
    for cnt in range(len(contours)):
        area = cv2.contourArea(contours[cnt])
        if max_area<area:
            max_area=area
            max_contour=contours[cnt]
    if return_area==True:
        return max_contour,max_area
    return max_contour

# get distance and slope between 2 points
def get_dist_and_slope(x1, y1, x2, y2,accurate_angle=False):
    distance = math.sqrt((x2 - x1) ** 2 + (y2 - y1) ** 2)
    try:
        slope = math.atan((y2 - y1) / (x2 - x1+.0000001))*180/math.pi
    except:
        slope=90
    if accurate_angle==True:
        # determine the quarter
        if (x2 - x1)<0 and (y2 - y1)>0:
            slope+=180
        elif (x2 - x1)<0 and (y2 - y1)<0:
            slope+=180
        if slope<0:
            slope+=360

    return [distance ,slope]

# get the number of fingers to use later
def get_the_no_of_fingers(parameter1,parameter2,parameter3,parameter4,parameter5,parameter6):
    text=""
    #  return no hand detected if area of contour is too small
    if parameter6 < 2000:
        return "no hand detected"
    # return 0 in case of  small parameter1
    if parameter1<1.20:
        return "0"
    elif parameter1<1:
        return"please put your hand in the frame"

    # parameter 5
    no_of_fingers_from_parameter5=0
    for i in range(len(parameter5)):
        if parameter5[i]!= 1000:
            no_of_fingers_from_parameter5 +=1
    # calculate parameter2,3
    no_of_fingers_from_parameter2=1
    no_of_fingers_from_parameter4=len(parameter4)-1
    for i in range(len(parameter2)):
        if parameter2[i] > 50000 and parameter3[i] < 90:
            no_of_fingers_from_parameter2 +=1
    # limit finger to [0:5]
    if no_of_fingers_from_parameter2>5 :
        no_of_fingers_from_parameter2=5

    if  no_of_fingers_from_parameter4>5:
        no_of_fingers_from_parameter4=5
    if no_of_fingers_from_parameter5 > 5:
        no_of_fingers_from_parameter5 = 5

    if no_of_fingers_from_parameter2<0 :
        no_of_fingers_from_parameter2=0

    if  no_of_fingers_from_parameter4<0:
        no_of_fingers_from_parameter4=0

    if no_of_fingers_from_parameter5<0 :
        no_of_fingers_from_parameter5=0

    # text=str(no_of_fingers_from_parameter2)+" or " +str(no_of_fingers_from_parameter4)+" or " +str(no_of_fingers_from_parameter5)
    text=str(round((no_of_fingers_from_parameter2 + no_of_fingers_from_parameter4 + no_of_fingers_from_parameter5)/3))
    return str(text)

# takes a binary image and return estimated parameters like area
def get_estimate_parameters(image):
    # parameter 1 hull area/contour area
    # parameter 2 area of triangle in defects
    # parameter 3 theta of triangle in defects
    # parameter 4 get the arclength of convex hull

    try:
        # draw stuff on a random image
        image2 = cv2.imread('1.jpg', 1)
    except:
        pass
    # determine contour
    contours, _ = cv2.findContours(image, cv2.RETR_LIST, cv2.CHAIN_APPROX_SIMPLE)

    # get the max contour
    contour=get_contour_max_area(contours)


    # find convex hull
    hull = cv2.convexHull(contour)

    # ////////// parameter 1 hull area/contour area
    # get convex hull area/contour area to indicate more gaps/fingers
    parameter1=cv2.contourArea(hull)/cv2.contourArea(contour)

    # get hull defects
    hull_false = cv2.convexHull(contour,returnPoints=False)
    defects = cv2.convexityDefects(contour,hull_false)

    # show hull and its defects
    # neglect very close points
    theta=[]
    triangle_area=[]
    hull_perimeter = cv2.arcLength(hull, False)
    hull_side_length = []

    for i in range(len(defects)):
        s, e, f, d = defects[i, 0]
        start = tuple(contour[s][0])
        end = tuple(contour[e][0])
        far = tuple(contour[f][0])
        distance,_=get_dist_and_slope(start[0], start[1], end[0], end[1])
        # ///////////////// parameter 2 area of triangle in defects
        triangle_area.append( 0.5 * d * distance)
        # draw convex hull
        # cv2.line(image2, start, end, [255, 0, 0], 2)
        # /////////// parameter 3 theta of triangle in defects
        #  get the angle of the triangle
        a1 = get_dist_and_slope(start[0], start[1], far[0], far[1])[0]
        a2 = get_dist_and_slope(far[0], far[1], end[0], end[1])[0]
        a3,a3_slope = get_dist_and_slope(start[0], start[1], end[0], end[1])
        theta.append(math.acos(((a1) ** 2 + (a2) ** 2 - (a3) ** 2) / (2 * (a1) * (a2))) * 180 / math.pi)
        # ////////// parameter 4 get the arclength of convex hull = no of fingers +1
        if (a3>25 and abs(a3_slope) <50) or (a3>100 ) :
            hull_side_length.append(a3)


        # if triangle_area[i]>50000 and theta[i]<90:
        #     # draw defects
        #     cv2.circle(image2, far, 5, [0, 0, 255], -1)

    parameter2 = triangle_area
    parameter3=theta
    parameter4=hull_side_length




    #  /////////////// parameter 5 circle or elipse whichever works
    # draw a circle that intersects with fingers
    (x,y),radius = cv2.minEnclosingCircle(contour)
    scaled_radius=radius/1.4


    # get intersection
    black_background1 = np.zeros_like(image)
    black_background2 = np.zeros_like(image)
    contour_only=cv2.drawContours(black_background1, contours, -1, (1, 1, 1), 15)
    # cv2.fillPoly(black_background1, pts=contour_only, color=(255, 255, 255))
    circle=cv2.circle(black_background2, (int(x), int(y)), int(scaled_radius), (1, 1, 1), 5)
    intersections=cv2.bitwise_and(contour_only, circle)
    # dilation
    # kernel = np.ones((3, 3), np.uint8)
    # intersections = cv2.dilate(intersections, kernel, iterations=2)
    intersections_contours,_=cv2.findContours(intersections, cv2.RETR_LIST, cv2.CHAIN_APPROX_SIMPLE)
    # get contours angles
    intersections_contours_list=[]
    for cnt in intersections_contours:
        (x1, y1), r1 = cv2.minEnclosingCircle(cnt)
        # cv2.circle(image2, (int(x1), int(y1)), int(r1), (255, 0, 255), 2)

        if (get_dist_and_slope(x,-y,x1,-y1,True)[1]>0 and get_dist_and_slope(x,-y,x1,-y1,True)[1]<190) or(get_dist_and_slope(x,-y,x1,-y1,True)[1]<0 and get_dist_and_slope(x,-y,x1,-y1,True)[1]>-30):
            intersections_contours_list.append(get_dist_and_slope(x,-y,x1,-y1,True)[1])

    # remove very similar angles
    for i in range(len(intersections_contours_list)):
        for j in range(len(intersections_contours_list)):
            if i==j  :
                continue
            # for distance
            if intersections_contours_list[j]>=intersections_contours_list[i]*.975 and intersections_contours_list[j]<=intersections_contours_list[i]*1.025 :
                intersections_contours_list[j]=1000

    # print(intersections_contours_list)

    # parameter5=len(intersections_contours)
    parameter5=intersections_contours_list

    # ////////////// parameter6 area of contour
    parameter6=cv2.contourArea(contour)
    # check if point is inside the contour
    # for i in range(len(circle)):
    #     a=cv2.pointPolygonTest(contour, tuple(circle[i]), False)





    #
    # ellipse = cv2.fitEllipse(contour)
    # cv2.ellipse(image2, ellipse, (0, 255, 0), 2)
    # parameter5 = 0

    # # ///////////// parameter 6
    # # find the distance between the convex hull and the center of the circle
    # distance_and_slope=[]
    # # eliminate very close pints
    # for i in range(len(hull)):
    #     distance_and_slope.append(dist_and_slope(int(x), int(y), hull[i][0][0], hull[i][0][1]))
    # for i in range(len(distance_and_slope)):
    #     for j in range(len(distance_and_slope)):
    #         if i==j  :
    #             continue
    #         # for distance
    #         if distance_and_slope[j][0]>=distance_and_slope[i][0]*.95 and distance_and_slope[j][0]<=distance_and_slope[i][0]*1.05 :
    #             # for slope
    #             if abs(distance_and_slope[j][1])>=abs(distance_and_slope[i][1]*.9) and abs(distance_and_slope[j][1])<=abs(distance_and_slope[i][1]*1.1):
    #                 distance_and_slope[j]=[0,0]
    # print(distance_and_slope)


    # show contour on plt.show

    # # draw contour
    # image2 = cv2.drawContours(image2, contours, -1, (0, 255, 20), 3)
    # cv2.circle(image2, (int(x), int(y)), int(scaled_radius), (255, 0, 255), 2)
    # # draw circle intersecting with contour
    # image2 = intersections
    # # show contour image
    # b=plt.figure(2)
    # plt.imshow(image2,cmap="gray")
    # # b.show()
    # plt.show()

    # return
    return parameter1,parameter2,parameter3,parameter4,parameter5,parameter6

# for air drawing use extreme points
def air_drawing(image):
    try:
        # determine contour
        contours, _ = cv2.findContours(image, cv2.RETR_LIST, cv2.CHAIN_APPROX_SIMPLE)

        # get the max contour
        contour,contour_area = get_contour_max_area(contours,True)
        if contour_area<2000:
            return (-1,-1)
        # get top point for finger index
        top_point = tuple(contour[contour[:, :, 1].argmin()][0])
        # make the point slightly lower for the finger
        x,y=top_point[0],top_point[1]
        return (x+50,y+65)
    except:
        return (-1,-1)

def mouse_control(image):
    try:
        no_of_fingers=main(image.copy())
        if no_of_fingers=="4":
            return "right"
        elif no_of_fingers=="5":
            return  "left"

        elif no_of_fingers=="1":
            # determine contour
            contours, _ = cv2.findContours(image, cv2.RETR_LIST, cv2.CHAIN_APPROX_SIMPLE)
            # get the max contour
            contour, contour_area = get_contour_max_area(contours, True)
            if contour_area < 2000:
                return (-1, -1)
            # get top point for finger index
            top_point = tuple(contour[contour[:, :, 1].argmin()][0])
            # make the point slightly lower for the finger
            x, y = top_point[0], top_point[1]
            return (x , y )
        else :
            return (-1,-1)
    except:
        return (-1, -1)

# takes an image and returns text to be displayed
def main(image):

    try:
        p1,p2,p3,p4,p5,p6=(get_estimate_parameters(image))
        return get_the_no_of_fingers(p1,p2,p3,p4,p5,p6)
    except Exception as e :
        # print(e)
        return "no hand detected !"


# #  for testing
#
# image = get_binary_image("11.PNG")
# a=air_drawing(image)
# print(a)
# # # draw contour
#
# b=plt.figure(2)
# plt.imshow(image,cmap="gray")
# # b.show()
# plt.show()
# image=get_binary_image("22.PNG")
# kernel = np.ones((3, 3), np.uint8)
# # mask = cv2.dilate(mask, kernel, iterations=4)
# image = cv2.erode(image, kernel, iterations=10)
# print(main(image))


'''
# if False:
#     # read images
#
#     image1 = cv2.imread('1.jpg', 1)
#     image2 = cv2.imread('4.jpg', 1)
#     image3 = cv2.imread('8.jpg', 1)
#
#     image1_binary=get_binary_image("1.jpg")
#     image2_binary=get_binary_image("4.jpg")
#     image3_binary=get_binary_image("8.jpg")



    # show binary image
    # a=plt.figure(1)
    # plt.imshow(image3_binary, cmap='gray')
    # a.show()
#
#     # find convex hull
#     hull=cv2.convexHull(get_contour_max_area(contours2))
#     image2=cv2.drawContours(image2, [hull], -1, (255, 0, 0), 3)
#     # get extreme points for air drawing
#     leftmost = tuple(get_contour_max_area(contours3)[get_contour_max_area(contours3)[:,:,0].argmin()][0])
#     rightmost = tuple(get_contour_max_area(contours3)[get_contour_max_area(contours3)[:,:,0].argmax()][0])
#     topmost = tuple(get_contour_max_area(contours3)[get_contour_max_area(contours3)[:,:,1].argmin()][0])
#     bottommost = tuple(get_contour_max_area(contours3)[get_contour_max_area(contours3)[:,:,1].argmax()][0])
#     print(leftmost,rightmost,topmost,bottommost)
#
#
#     # draw a circle
#     (x,y),radius = cv2.minEnclosingCircle(get_contour_max_area(contours3))
#     cv2.circle(image3,(int(x),int(y)),int(radius),(0,255,0),2)
#     #  draw  an elipse
#     ellipse = cv2.fitEllipse(get_contour_max_area(contours3))
#     cv2.ellipse(image3,ellipse,(255,255,0),2)
#     # match 2 shapes
#     result = cv2.matchShapes(contours3[0], contours2[0], 1, 0.0)
#     # compare arera and perimeter
#     perimeter = cv2.arcLength(get_contour_max_area(contours3), True)
#     _, area = get_contour_max_area(contours3, True)
#     (area / perimeter)
#     #     get hull defects
#     image2 = cv2.drawContours(image2, [hull], -1, (255, 0, 0), 3)
#     defects = cv2.convexityDefects(cnt,hull)

   # distance=[]
    # for i in range(len(hull)-1):
    #     dist=get_dist_and_slope(hull[i][0][0],hull[i][0][1],hull[i+1][0][0],hull[i+1][0][1])[0]
    #     if dist>hull_perimeter*0.1:
    #         distance.append(dist)
    # parameter4=distance
    # print((parameter4,hull))
# trash

# img1=get_binary_image('7.jpg')
# img2=get_binary_image('6.jpg',180)
#
# contours,hierarchy = cv2.findContours(img1,cv2.RETR_LIST, cv2.CHAIN_APPROX_SIMPLE)
# cnt1 = get_contour_max_area(contours)
# contours,hierarchy = cv2.findContours(img2,cv2.RETR_LIST, cv2.CHAIN_APPROX_SIMPLE)
# cnt2 = get_contour_max_area(contours)
# contours,hierarchy = cv2.findContours(img2,cv2.RETR_LIST, cv2.CHAIN_APPROX_SIMPLE)
# cnt3 = get_contour_max_area(contours)
'''


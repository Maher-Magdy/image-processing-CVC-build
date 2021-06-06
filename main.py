import cv2
import threshold_module
import contour_module
import numpy as np
import mouse
import pyautogui
cap = cv2.VideoCapture(0)
cap.set(3,640)
cap.set(4,480)
flag =1
point_list=[]
count=0 #frame counter
try:
    with open( "mode.txt", "r+") as input:
        for line in input:
            flag=int(line)
except:
        pass

while True:
   _, image = cap.read()
   m = threshold_module.mask(image)
   if flag==0 :
        text=contour_module.main(m)
        org =(0,image.shape[0])
        # show the text on window
        cv2.putText(image, text, org, cv2.FONT_HERSHEY_SIMPLEX, 2, (150, 10,200), 5, cv2.LINE_AA)
        cv2.imshow("video", image)
        #cv2.imshow("mask",m)
        #print(contour_module.main(m))
   elif flag==1:
       # try:
        if count%5==0:
            point=contour_module.air_drawing(m)
            if point ==(-1,-1):
                if len(point_list)==0:
                    point=(150,150)
                else:
                    point=point_list[-1]

        point_list.append(point)
        cv2.circle(image,point,2, (0, 0, 255), 10)
        for pnt in range(len(point_list)):
                if count!=0 and pnt>1:
                        cv2.line(image,point_list[pnt-1],point_list[pnt], [255, 0, 0], 2)
       # except:
       #     pass
        cv2.imshow("video", image)
   elif flag==2:
       if count % 5 == 0:
           command=contour_module.mouse_control(m)
           if command!=(-1,-1): # ignore (-1,-1) as it represents an error
               if command =="left":
                   mouse.click('left')
               elif command == "right":
                   mouse.click('right')
               else: # move the mouse
                   # scale the mouse position to cover the whole screen
                   x,y=pyautogui.size()
                   x=round(command[0]*x/300)
                   y=round(command[0]*y/300)
                   mouse.move(x,y, absolute=False, duration=0.1)
            #    mouse move and click

       cv2.imshow("video", image)

   #   to quit press 'q'
   k = cv2.waitKey(1) & 0xFF
   if k == ord('q'):
           break
   #  increase frame counter
   count+=1
# close
cv2.destroyAllWindows()
cap.release()



# trash
#  trying to approximate and remove noise
# a = np.zeros_like(image)
# for i in range(len(point_list)):
#       a[point_list[i][0]-50][point_list[i][1]-50] = 255
# contours,_=cv2.findContours(a,cv2.RETR_LIST,cv2.CHAIN_APPROX_SIMPLE)
# approx = cv2.approxPolyDP(contours[0], 1, True)
# cv2.drawContours(image, [approx], -1, (255, 0, 0), 3)
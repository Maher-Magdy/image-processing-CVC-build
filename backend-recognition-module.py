import cv2
import numpy as np
import matplotlib.pyplot as plt
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

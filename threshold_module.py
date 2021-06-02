import cv2
import numpy as np
kernel = np.ones((3, 3), np.uint8)
def mask(image):
    # define region of interest
    green_frame = image[50:350, 50:350]
    cv2.rectangle(image, (50, 50), (350, 350), (0, 255, 0), 0)
    hsv = cv2.cvtColor(green_frame, cv2.COLOR_BGR2HSV)
    # define range of skin color in HSV
    lower_skin = np.array([0, 20, 70], dtype=np.uint8)
    upper_skin = np.array([20, 255, 255], dtype=np.uint8)
    # extract skin colur imagw
    mask = cv2.inRange(hsv, lower_skin, upper_skin)
    # extrapolate the hand to fill dark spots within
    mask = cv2.dilate(mask, kernel, iterations=4)
    mask = cv2.erode(mask, kernel, iterations=9)
    # blur the image
    mask = cv2.GaussianBlur(mask, (5, 5), 100)
    image = cv2.flip(image, 1)
    return mask

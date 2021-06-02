import cv2
import module
import contour_module
cap = cv2.VideoCapture(0)
cap.set(3,640)
cap.set(4,480)
while True:
        _, image = cap.read()
        m=module.mask(image)
        text=contour_module.main(m)
        org =(0,image.shape[0])
        cv2.putText(image, text, org, cv2.FONT_HERSHEY_SIMPLEX, 2, (150, 10,200), 5, cv2.LINE_AA)
        cv2.imshow("video", image)
        #cv2.imshow("mask",m)
        print(contour_module.main(m))
        k = cv2.waitKey(1) & 0xFF
        if k == ord('q'):
            break
cv2.destroyAllWindows()
cap.release()
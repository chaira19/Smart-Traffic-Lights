import numpy as np
import cv2
import time

x=200
y=200
h=800
w=600

cap = cv2.VideoCapture('testvideo.mp4')
time.sleep(2)
# Define the codec and create VideoWriter object
fourcc = cv2.VideoWriter_fourcc(*'XVID')
out = cv2.VideoWriter('output.mp4',fourcc, 20.0, (640,480))

while(cap.isOpened()):
    ret, frame = cap.read()

    gray = cv2.cvtColor(frame, cv2.COLOR_BGR2GRAY)

    crop_frame= gray[y:y+h, x:x+w]
    # write the flipped frame
    out.write(crop_frame)


    cv2.imshow('frame', crop_frame)
    if cv2.waitKey(10) & 0xFF == ord('q'):
        break

cap.release()
out.release()
cv2.destroyAllWindows()
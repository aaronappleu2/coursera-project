import zipfile

from PIL import Image,ImageDraw
import pytesseract
import cv2 as cv
import numpy as np
import time

# loading the face detection classifier
face_cascade = cv.CascadeClassifier('readonly/haarcascade_frontalface_default.xml')

# the rest is up to you!

# convert image to string
# and store the image which has the word looking for
def detectText(text, names):
    new_names = []
    for name in names:
        whole = pytesseract.image_to_string(Image.open(imgZip.open(name, mode='r'), mode = 'r'))
        if text in whole:
            new_names.append(name)
    return new_names


# detect faces in images and resize them, store them in dictionary
def dectectFace(new_names):
    faces_dict = {}
    for name in new_names:
        face_imgs = []
        news = Image.open(imgZip.open(name, mode='r'))
        gray_version = news.convert('L')
        gray_version.save('gray_{}'.format(name))
        cv_img = cv.imread('gray_{}'.format(name))
        faces = face_cascade.detectMultiScale(cv_img,
                                              scaleFactor=1.35,
                                              minNeighbors=4,)

        for x,y,w,h in faces:
            tmp=news.resize(size=(100,100),box=(x,y,x+w,y+h))
            face_imgs.append(tmp)

        faces_dict[name] = face_imgs
    return faces_dict

# paste dectected faces on blank image then display
def drawResults(face_imgs):
    # draw rectangle
    x = 500
    y =100*(len(face_imgs)//5+1)

    result_img = Image.new('RGB',(x,y), color=0)
    px = 0
    py = 0
    for face in face_imgs:
        if px ==500:
            px = 0
            py+=100
        result_img.paste(face,box = (px,py,px+100,py+100))
        px+=100
    display(result_img)

# Main process

imgZip = zipfile.ZipFile('readonly/small_img.zip',mode = 'r')
names = imgZip.namelist()
text = input('Search for: ')
new_names = detectText(text, names)
faces_dict = dectectFace(new_names)

for name in new_names:
    print('Results found in file {}'.format(name))
    if len(faces_dict[name]) != 0:
        drawResults(faces_dict[name])
    else:
        print('But there were no faces in that file!')

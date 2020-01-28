# Find triangle on image using Windows Forms and OpenCV
The application find triangles on image. Written using **Windows Forms**. 
Load image, choose what type of triangles to look for and you'll get the triangles circled and sorted by area in descending order.

![TrianglesFound](https://raw.githubusercontent.com/lucky125111/TriangleRecognition/master/Screenshots/TrianglesFound.png)

## Usage
If you just want to run the application you can download the `dist/` folder. Then double click on `GUI.application`

![TriangleRecognition](https://raw.githubusercontent.com/lucky125111/TriangleRecognition/master/Screenshots/TriangleRecognition.gif)

### Requirements
Application runs only under Windows. If you don't have .NET run time installed run `dist/setup.exe`

### Develop 
To clone and run project you can use script `build.bat` 
```
git clone https://github.com/lucky125111/TriangleRecognition.git
cd TriangleRecognition
build.bat
```

## Functions

1. You can choose what image you want to load (a few are included in the **InputData** folder)
2. You can choose what color the triangles should be
3. You can choose how many triangles you want to look for

Triangles are sorted from the one with the biggest area to the smallest.

## How it works
How the shapes are detected:
1. The image is thresholded in relation to the color for which we are looking for shapes (the threshold removes the noise that is on the picture very well)
2. Next, the contour of the found shapes is determined
3. For each contour we find a polygon approximating this contour
4. If the polygon has 3 vertices then it is a triangle, we add the triangles to the result list
5. Take the appropriate number of the largest triangles from the result list

The application looks for all polygons on picture, then returns only ones with 3 vertices. This approach is good for artificial data but probably won't work on real life examples.

## Remarks
### 1. Application uses Windows Forms
### 2. I wanted to do something with OpenCV (I used .NET wrapper for OpenCV)

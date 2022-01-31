# AgSwift

The goal of the project was to create an earthwork estimator, similar to AgTek Sitework 4D (https://www.agtek.com/sitework4d.html), but as a free and open source solution. The reason I chose the project was because I previously worked at a small company in Fresno that provided earthwork estimations using Sitework 4D, so I had some experience with the software and had a general idea of how it worked.

The purpose of the software is to generate an estimate of the amount of earth needing to be transported around a construction site (called the cut-fill map), and the amount of concrete, asphalt, and other materials that will be necessary for the non-architectural components of the site, such as sidewalks, building pads, access roads, and parking lots. Estimates like these are useful because contractors can use a more accurate estimate to bid for the contract more competively. 

To begin using the software, you first need a topographical survey and a civil design plan for a construction site, ideally in PDF form. Starting from either the Existing or Proposed Bluprint modes, the user then imports the PDF file containing the topographical survey (i.e., the existing blueprint), or the civil design plan (i.e., the proposed blueprint), selecting the page they wish to convert into an image, which will be displayed on the drawing surface.

(An example of a topographical survey, in this case combined with a "demolition plan")

![unknown](https://user-images.githubusercontent.com/18123941/151679422-2951c7ca-601f-43bc-8d2f-0df1c5609ef8.png)

(An example of a civil design plan)

![unknown](https://user-images.githubusercontent.com/18123941/151679436-5d97bf0d-2a53-4f3a-9bb2-7c6f87ed0ce2.png)

The user can then begin entering points by first typing in the elevation (indicated on the PDF page somewhere near the point), and then clicking on the point's location on the drawing surface. Users can connect multiple points with edges, where appropriate, or can stop the edge placement by right-clicking. The more elevation points that are entered, the more accurate the resulting estimate will be.

![unknown](https://user-images.githubusercontent.com/18123941/151679440-4fa63271-3c3a-46db-b7b7-4e8c94686e8f.png)

Once the user has entered all points and edges from the topographical survey and civil design plan, they can calculate the cut-fill amount for the entire site by clicking on the Calculate Cut/Fill button. This amount determines whether earth will need to be imported onto the site, or exported off of it (negative values indicate importing earth is necessary).

This earthwork calculation is somewhat complicated and involves a few steps. First, the points that the user entered are triangulated using the Delaunay method, and then constrained by the edges entered by the user. This is known as a "constrained Delaunay triangulation". The program then loops over the length of the X-axis of each blueprint simultaneously. On each loop, the points along the length of the Y-axis are measured. In places where the existing and proposed blueprints overlap, the difference in elevation is recorded. Because the steps of each loop are discrete, we can assume a unit area for each step, thus providing an estimated volume difference for that unit area. By adding up each discrete volumetric difference, we can estimate the volumetric difference over the whole site with reasonable accuracy.

![unknown](https://user-images.githubusercontent.com/18123941/151679449-e76e32ca-2e92-463c-8d1f-a778c878cc63.png)

(Profile view along the y-axis)

![unknown](https://user-images.githubusercontent.com/18123941/151679460-f2fb997f-88be-4f6f-b275-ea9138055d91.png)


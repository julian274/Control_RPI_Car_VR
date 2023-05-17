# PI-Car VR

In this project, I managed to control the Sunfounder Raspberry PI car v2.0 via the Meta Quest 2 controllers. Using unity.
It was challenging to work on this project.
I encourage anyone that is interested in this project to get your hands on the RPI Car and continue working on what i have started.

## Steps to use the code: 
1- Install the Raspberry PI OS on the Car.

2- Clone the source code https://github.com/sunfounder/SunFounder_PiCar-V .

3- U can see the instructions about how to start the car here: https://docs.sunfounder.com/projects/picar-v/en/latest/ .

4- Clone this unity Project that is in this repository https://github.com/julian274/Control_RPI_Car_VR .

5- Follow these steps to run the car:
   - Send these commands to run the server 
```
     cd ~/SunFounder_PiCar-V/remote_control

     python3 manage.py migrate

     sudo ./start
          
```
To run the MJPEG Streamer u need to download the requierd files then follow these commands on a different terminal (because we want to execute two commands together):
```
#First
cd SunFounder_PiCar-V

#Second
cd mjpg-streamer

#Third
chmod +x mjpg_streamer

#Last Thing
./mjpg_streamer -i "./input_uvc.so -r 640x320 -f 30 -q 100" -o "./output_http.so -w ./www"

#Or to create a HTTP server for snapshots using MJPG-Streamer, you can use the following command:
./mjpg_streamer -i "./input_uvc.so -r 640x320 -f 30 -q 100" -o "./output_http.so -w ./www_snapshot"

```
6- Connect the VR to your PC, and download the requierd VR packeges.

7- Run the project on Unity.

8- Final Step divertiti (HAVE FUN).

## SCRIPTS:

### "SanpshotStreamViewer.cs" 
This is the code that I'm using in Unity to view the stream. I'm reading from a snapshot server 30fps. and un pause for 4 times it works fine.

### Car.cs Code Explination:

I defined a new function named "SendCommand" that assest me to call the Car API without to do initialize every single time the client from the begining, we send to this function the url that we want to get to and the function will call tha API.
Use W,A,S,D keys to control the car and the arrow keys to control the camera using unity, using Car.cs script.
Each key sends an http request to the server that runs on the car.

### VRControl.cs Explination:

We use this script to control the car movment with the META QUEST 2 controllers.
You can upgrade this script, you need just to play with it untill it works smoothly.
 
## Thanks and Credits

I would like to express my sincere gratitude to the University of Haifa and my mentor, Prof. Roi Poranne, for their invaluable support throughout this project. This project was conducted under the guidance of Prof. Roi in the Computer Graphics Laboratory.

I would like to extend a special thanks to Prof. Roi Poranne for his mentorship, expertise, and continuous encouragement. His guidance has been instrumental in shaping my understanding of computer graphics and helping me achieve my goals.

# Enjoy!!!
 

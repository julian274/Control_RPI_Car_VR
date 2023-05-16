# PI-Car VR

In this project, i want to control the Sunfounder Raspberry PI car v2.0 via the Meta Quest 2 controllers. I am using unity.

For this momment i'm using the W,A,S,D keys to control the car and the arrow keys to control the camera using unity.

Each key sends an http request to the server that runs on the car.

The goal is to use the vr controllers to control the car.

## Steps: 

1- For the first two weeks i tried to get access to the user that was downloaded to the Raspberry PI OS, but the password was incorrect, i tried every thing to change it but it did't work.

2- I faced a problem with the car build the hdmi cable was not gonna fit i had to remove a motor to connect it so i had to work on the car itself to raise the Raspberry PI Chip to get access to the hdmi input.

3- So i had to reinstall the OS on the Car and re-do all the setup from scratch, I Loged in via new user named "PI" and the default password was "raspberry" I have changed it to "123".

4- I cloned the source code from this repository: https://github.com/sunfounder/SunFounder_PiCar-V

5- Then I was running the server on port 8000. 

6- To run the server first of all we need to connect the car to wifi, then log-in to the user "PI" after that we just send "./startCar" to run the server.

7- I defined this command to run the server ```
./startCar" to make a shortcut and do not write all of this command:
"cd ~/SunFounder_PiCar-V/remote_control
python3 manage.py migrate
sudo ./start"
```
8- I have written a C# file that i uploaded to this repository named "Car.cs" that when i run it I can control the car via unity using W,A,S,D and control the camera using the arrows on the keyboard.

9- "SanpshotStreamViewer.cs" This is the code that I'm using in Unity to view the stream. I'm reading from a snapshot server 30fps. But i still getting the same error but after i pause and un pause for 4 times it works fine.


### Important update: It seems like the source code that they told me to clone in the servo configiration docs and the server run command does not run the mjpeg streamer. It runs an HTTP server that can not stream on unity because its not a snapshot or a stream. The servo confi told me to clone a branch V3.0 of the source code. And to add for this there is no command to run the mjpeg streamer or there is no command to let me know the server that runs on the mjpeg streamer.
In my last two weeks I have been working on unity just to make the mjgeg stream appear on unity the issue is that the mjpeg streamer was never running.
There is two ways to solve this problem the first one is to find a way to run the mjpeg streamer then to find the URL that i can see it and put it in unity, and the second one is to modify a new function in the source code and then clone it again to the Car, the function will be to take snapshots every second or 3 snapshots every second and in unity we will do a loop that gets these snapshots to create a video.

## Update:

The very last update is that i have managed to run the mjpeg_stremer and i can now see the stream via the mjpeg streamer. This is a progress for me because at first i could't play the mjpeg_streamer, I downloaded packages so i can run the mjpeg streamer that they were not in the source code.
We need to do : 
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
### Today's Update: "SanpshotStreamViewer.cs" This is the code that I'm using in Unity to view the stream. I'm reading from a snapshot server 30fps. But i still getting the same error but after i pause and un pause for 4 times it works fine.
I'm writing a code to control the car using the Meta Quest 2 controllers.

## Car.cs Code Explination:

I defined a new function named "SendCommand" that assest me to call the Car API without to do initialize every single time the client from the begining, we send to this function the url that we want to get to and the function will call tha API.

## VRControl.cs Explination:

Its just the first script for now, I want to try it first then I'll update it if necessary.
 
# Finnished 


 

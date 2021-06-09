# Haptic-Enabled-Manipulation-via-Event-Based-Tactile-Sensor-in-Augmented-Reality

## Abstract 
In the modern world, there is a need to strive to minimize various risks in production, as well as simplify the work of the operator during the robot control. Yet there is a piece of missing information as the tactile properties (texture, solidness) of the object being manipulated as well as the lack of tactile sensors that can show high-speed performance. Our work proposes a multidisciplinary solution for the problems listed in the form of three separate parts combined into one whole system. Those are: 1) Haptic device for the robot control and tactile feedback. 2) Event-based tactile sensor for precise sensation for texture recognition and force detection. 3) Force and robot visualization in augmented reality (AR). Each of the parts was developed and proven as a working piece of the whole project. Some of the parts proved their work experimentally, while others were proven practically. As a result, the authors showed that a haptic device for the robot remote control with an advanced tactile sensor and visualizations in AR may improve user perception and system controllability overall.

## Chapter 1: Introduction
The project is built around the idea of haptic robot control and visualization. Each team member separately developed the application and started the integration of the system as a whole. The idea is that the user wearing the Augmented Reality headset, namely HoloLens, manipulates the robot using the haptic device. The properties such as texture, solidity or softness of the object are detected by an event-based tactile sensor and sent as haptic feedback to the haptic device and are also visualized in augmented reality.

![1](https://user-images.githubusercontent.com/67557966/121356038-5249c680-c952-11eb-9f94-5b4758237d7f.jpg)

The core of the project is the Robot Operating System (ROS) which allows the easy integration of all those developments into one complete system. Figure 1.1 The authors describe
each design in a separate chapter.

Chapter 2 describes the haptic device and experiment conducted using a Virtual Environment in order to prove the concept.

In Chapter 3 authors described the event-based tactile sensor, which has capabilities of detecting force direction, texture and gives the data back to the user in the face of haptic feedback on the tips of the fingers.

Visualizations of robot state and sensed force in augmented reality are described in Chapter 4. It includes software that was used as well as solutions that the authors implemented and the limitations.

The last Chapter 5 contains information about full assembly and system integration. The methods used for communication and tuning are also described there.

## Chapter 2: Haptic Device

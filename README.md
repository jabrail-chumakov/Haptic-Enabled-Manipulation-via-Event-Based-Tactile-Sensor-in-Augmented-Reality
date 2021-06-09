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
### 2.1 Introduction
There are certain requirements for the haptic devices, such as the capability to perceive as static contact as well as dynamic contacts [1]. If the solution for the static feedback is straightforward, the dynamic feedback has its own nuances. When a human is manipulating the physical object dynamically, he/she is capable of characterizing the object’s internal structure based on the displacement of fingers in case of direct contact [2]. Our team focused on simulating the kinesthetic displacement of the elbow via the haptic feedback on the applied force. The Virtual Environment (VE) with the Head Mounted Device (HMD) was used to create a pseudo-haptic effect that had to be strengthened by a stimulus on the tip of the fingers.

Before integrating the full system, the authors proved the concept of haptic device experimentally and showed that haptic feedback is capable of extending perceptions of the environment for a user. The work was submitted to the conference in the scope of the graduation project.

### 2.2 Related Work
The paper by Pacchierotti et al. [3] was aimed to solve the issue of delivering tactile feedback for enhancing the haptic feedback in Virtual Reality or Augmented Reality as well as providing tactile sensations while operating the robot remotely and for the rehabilitation. Authors were inspired by several startups and focused on device mobility, ease of use, and lightweight since those solutions were wearable. The authors developed a lightweight device that was attached to the finger’s tip and had a battery for a seamless experience. In order to deliver the full experience to the user, virtual reality headset was used.

Finger mounted device has two main components, the servo motor, which squeezes the finger and the voice coil motor, which gives the haptic feedback from the texture of the virtual surface. In order to track the hand’s movements, the leap motion device, which was mounted onto the VR headset was used. In order to validate their model, the authors conducted an experiment where they asked 12 participants to try three different surfaces. Next, the virtual model of texture was turned black and participants were asked to guess the given texture based on haptic feedback.

The authors evaluated their results based on the survey conducted among the test group. They were asked to score the haptic feedback of the device and the comfort of use from 0 to 10 points where the range goes from ”very low” to ”very high”. The rating was 8.3 for feedback and 7.9 for comfort. Also, the correctness of surface identification based on the haptic feedback is rated as 63 % with a deviation of 15 %, which shows that the guesses were not based on chance. (1/3 which is 33%)

Both the design of the model and modelled textures and haptic feedback were based on the other works. The device was build based on work done by Pacchierotti et al., which was a review paper of the wearable haptic devices. Also, the textures and haptic modulations were taken from the open-source database of the Penn Haptic Texture Toolkit (HaTT). Thus, the contribution made by authors is the optimization for ease of use and wireless control.

### 2.3 Experimental Setup
The figure 2.1 shows the workflow of the experimental setup. Because the system used Robot Operational System (ROS) for hardware integration which works well on Linux based operational systems while VR headset as well as Unity software are available only for Windows based machines, it was decided to use two PC and communicate between using socket communication over TCP/IP protocol.

![2](https://user-images.githubusercontent.com/67557966/121357360-92f60f80-c953-11eb-9126-a6e1b7dd4ae3.jpg)

### 2.3.1 Hardware
The core parts of the experiment were: VR headset, Leap Motion Controller, and the device itself. The body of the device was made of PLA polymer and printed on Ultimaker S5. For the haptic stimuli generation, the voice coil actuators were used. In order to deliver the stimuli on each finger and to be able to control the type of vibration on each finger (i.e., sending different vibrations on each motor), the device was build for two motors (figure 2.2). Since the device is held from two sides with the tips of the fingers, the cutouts were made for a comfortable grip for each finger (Figure 2.2).

The vibrations were generated using a data processing board (Teensy USB Board, Version 3.6, PJRS, USA) and amplified by Class-D Type amplifiers (Adafruit Mono 2.5W Class D Audio Amplifier - PAM8302, Adafruit Industries, USA) designed especially for the audio applications. The operating range of the motors (from 90 Hz to 1000 Hz) allowed to variate the vibration modes.

To avoid the absorption of vibrations by the ground the motors were isolated by 4 springs on each side which adds up to a total of 8 springs for a whole device. Each spring has a constant of k = 200N/m which is enough to keep the actuators stationary in relation to the device’s enclosing structure and damp vibrations. Under the maximum vertical load of 16.5 N, the change was less than one millimetre. This move can be overlooked because it is much smaller than the hand’s displacement in virtual reality.

![3](https://user-images.githubusercontent.com/67557966/121357625-c3d64480-c953-11eb-8db8-1406dd7421db.jpg)

The system was mounted on the force sensor (Weiss KMS 40-C, Weiss Robotics, Germany) which has standardized threads that allow attaching the plastic body to motors (Figure 2.2) as well as attaching the whole assembled device onto the optical table so that it is rigidly mounted with no movements (Figure 2.4). Vibrations generated on the device are also transmitted through air, as a result of which a testee’s judgment could be affected by audio clues, which may distort the results of the experiment. Thus, noise-cancelling headphones were used during the experiments.

### 2.3.2 Software
Since the 6 axis force sensor has ready-made packages for the Robot Operating System (ROS) and it is the crucial part for communication between other parts of the project. However, since HMD is compatible only with the Windows OS running machines, socket communication was established between the computers.

One of the components of the experiment was the Leap Motion Controller. The virtual stick was attached to the hand model generated by lip motion. It had a collider part (an invisible mesh of object form used to simulate physical collision events) that interacted with the collider of a sphere. As a result, the squeeze effect was applied using real-world hand gestures as it can be seen from figure 2.3.

The experiment required the people to look at their real hands in VE, thus, the Leap Motion Controller was connected and the hand with a stick attached to it was simulated in VE. 
![4](https://user-images.githubusercontent.com/67557966/121358042-1b74b000-c954-11eb-89c4-c25b14fda263.jpg)

### 2.3.3 Methodology
To validate the devices’ working principle, the authors conducted experiment in VE. There were 3 types of vibrations and 3 force limits together with the ”no vibration” mode there were 13 modes overall. The vibrations were divided according to the sampling rate of data and phase for each mode. Thus, there were 3 force limits: 6.5N, 11.5N and 16.5N. Also, 3 vibration modes with φ = 0.1, 0.5 and 0.5 where each mode had their own rate of force rate sampling with dt = 10, 5, 2 ms, respectively.

The output from the DAC port to motors come as a sinusoidal function:
![5](https://user-images.githubusercontent.com/67557966/121358251-48c15e00-c954-11eb-88c5-0fbfb33d6bf0.jpg)
, where v is the output, φ is the constant phase for each mode and R is the rate of force that was normalized.

The same force limits as for vibrations were used in virtual stick and hand displacement, as well as ball, squeezing function, which is linearly related to the applied force.

![6](https://user-images.githubusercontent.com/67557966/121358441-71495800-c954-11eb-890e-ba4fd49f3521.jpg)

The experiment consisted of 10 testees where each was pressing the simulated ball with their hand (that was tracked by leap motion controller) for the sake of understanding the scales of the environment. Further, the virtual hand was replaced by a fixed hand that moves along only one axis (Z, along the direction of the applied force) and the testee was asked to place his real hand on the device (Figure 2.4). For each mode, the testee was asked to try to press the ball 5 times and report the distance of the hand’s movement. In total there were 65 (5 times each mode) modes for each testee with 5 iterations on each mode.

### 2.4 Results Evaluation
The experiment results are overall acceptable. First of all, for the three modes, the result of the analysis of variance (ANOVA) showed that only the middle phase mode (φ = 0.5 and dt = 5) gave significant results, while the other two were just tolerable. However, it was enough to prove the concept, since the effect of haptic illusion took place with fully closed eyes. The combination of pseudo-haptics with haptic illusion works well under certain conditions where the vibration plays an important role.

Additionally, the chosen size of the virtual ball (10 cm, measured with respect to the hand model) appeared to be too large and the testees evaluated the results leaning more on visual clues rather than the haptic sensation.

### 2.5 Conclusion
In conclusion, the device was proven to be working. The authors were able to build a setup that can be integrated into other applications. Even if the result of the experiment was not fully proving the concept of a haptic device, it was enough to show that certain haptic feedback gives the illusion of real elbow movement. The experiment also showed that there is room for improvements such as the classification of objects that are being pressed (i.e. soft, solid and granular objects). Since authors used ROS for VE and generation force from a sensor, it will be easier to integrate the full system with haptic feedback from the event-based tactile sensor and robot control using the device as it is described in further sections.

## Chapter 3: Event-Based Tactile Sensor
### 3.1 Introduction
Human-like artificial tactile sensing is the major technology in dexterous manipulation which started to gain popularity recently. The development of more sophisticated biomimetic tactile sensors that can imitate human touch is a necessary feature since they can lead to safer and more intuitive industrial robots. Current sensors do not have high processing speed and temporal resolution, especially vision tactile sensors. Although there are cameras with a large frame rate of up to 1 kHz, they are power consuming and bulky.

Currently, there are already some tactile event-based cameras. However, they still have some drawbacks. The elastic body of such sensors does not have a long lifetime due to constant contact with rough surfaces. Another drawback is that without any movements markers stand still, which leads to loss of information in some cases. In this research, the authors found a solution to these problems by adding some additional features like whiskers which will be connected to the markers and several LEDs which will emit light with high frequency.

### 3.2 Related Work
Tactile sensing is a major technology in dexterous manipulation. In this paper, a new method of human fingertip imitation was proposed[4]. However, currently, all sensors have a slow rate. Especially the ones that rely on the vision tactile sensing. All cameras’ frame rates are too low. Although there are cameras with a rate of up to 1 kHz, they are power consuming and bulky. The solution to this problem is an event-based camera, which stores the data continuously 3.1.

An elastic body, which contains a lot of reflective markers, is attached to the event-based camera lens. When the force is applied to the elastic sensor, the camera can detect the movements of the markers. By measuring the displacement between the markers, different information such as force shape and surface friction can be estimated. Slip detection was trained by a robot arm which slid the elastic body along the surface. Shape recognition was trained by pressing the sensor with a bolt under different angles.

Fast slippage detection with the use of a tactile vision sensor was implemented. Even after processing, the sensor had 500 microseconds resolution and a 32x32 array, which brings much variety of features that will be used for later recognition.

Industrial robot arms need to detect slippage immediately, so they will not drop the objects. Currently, there are not many sensors that can do it at high speed. Especially with the presence of vibrations and other noise.

The robot grabs the object with transparent plates, having an event-based camera staring at one of the plates. An object is marked with different shape figures, so the camera can detect when the object starts to fall. A noise that occurs due to light and robots’ vibration is handled with offline calibration.

![7](https://user-images.githubusercontent.com/67557966/121359982-d5b8e700-c955-11eb-81b1-cf8e129cec9c.jpg)

Event-cameras showed fundamentally different sensing mechanics than the conventional ones. Average slip metric values obtained from complete robotic object manipulation experiments validated high-performance precision manipulation. The principal objective of neuromorphic engineering is to develop technologies that can exploit efficient representations of information and operate in a rapid, power-efficient manner[5]. The main goal of this paper is to produce a sensor that can validate texture classification task.

One more paper presents a new way of texture recognition using event-based camera[6]. Besides being robust it is highly accurate in detecting changes, and that will help in consequent surface recognition.

Several different cameras (DAVIS420, iniVation) were used in this experiment for texture recognition. According to the number of spikes(movements) during the slide, the texture was recognized. Features were extracted in several ways.

- Intensive: All number of spikes were divided by the number of markers
- Spatial: All number of spikes were assigned to each marker
- Temporal: Average number of spikes in specific time zone
- Spatio-temporal: Special Van Rossum algorithm were used for this coding

### 3.3 Approach
As it was mentioned previously, an elastic body with four reflective markers will be put on the lens of an event-based camera. Whiskers are connected to each marker, so the sensor can always interact with the surface through them. The whiskers were designed for more soft interaction with the surface. With them, the silicon part of the sensor will not get damaged due to contact with some rough surfaces.

The additional adapter is placed between the lens and markers, so no outer light can enter the camera sensor. An adapter will be filled with a number of LEDs which will give light with constant frequency, so an event-based camera will always have a full vision of the sensors. All LEDs will be connected to the STM32 microcontroller parallel to each other in order to have the same frequency.

The exploded view of the whole set-up can be seen in Figure 3.1. When the force will be applied on the sensor, distances between the markers must be consequently extended. The event-based camera will immediately catch the change in position. After several repetitions and estimation of correlation between the force and the distance, in further experiments force will be easily calculated.

![8](https://user-images.githubusercontent.com/67557966/121360562-5a0b6a00-c956-11eb-8fec-d88abd5887c7.jpg)

### 3.4 Results Evaluation
For this project, we used Metavision Essentials SDK 2.1 software which was designed specifically for the Prophesee event-based cameras and sensors. So far we have settled the software, so it can identify markers and put them in the box as you can see in Figure 3.3. Also, this figure illustrates the sensor’s appearance from the inside. From the illustrations, it can be seen that with the applied force marker’s position significantly change. We extract center coordinates of the boxes and send them to Unity for visualisation and later they will be sent to industrial robot Franka Emica via Robot Operating System.

Currently, the new design for the setup was implemented. Present setup has a fewer number of joints which leads to more stable contact. Also, instead of the silicon body just hanging on the lens, now it is connected to the core of the setup, so the bond is more solid and relies on the whole setup rather than just on the lens as it was in the prototype. Another updated feature is that we increased the number of LEDs from 3 to 6, so the vision of the event-based camera was improved. The optimal frequency of the LEDs was estimated to be around 1000 Hz, which is fast enough to receive all the required data. Without the light given with constant frequency event-based camera would not be able to see the markers when they are standing still and this might cause a further problem in the estimation of their location and force estimation.

During the identification of the markers, boxes were flickering or changing the size due to the presence of some noise. Since it led to the displacement of the center coordinates, relative distances were also exposed to frequent change. We deduced the high frequencies by applying the low-pass filter as you can see in the Figure 3.4.

![9](https://user-images.githubusercontent.com/67557966/121361089-c8502c80-c956-11eb-9a1f-60cd80134ed9.jpg)

### 3.5 Conclusion
For future work, we can adapt the new algorithm, which will estimate not only the normal force but also tangent forces across the plane which can be occurred due to the friction of the surface. The processing of such events will be made in MATLAB, where different codings from the NeuroTac paper will be examined in order to achieve the best result. Another great feature that can be implemented is texture recognition with the use of whiskers. Another way to improve the robustness of the sensor is to change the calculation of measuring the distances while correlating them with the applied force. There are also a lot of approaches to develop the elastic body. We can increase the number of markers, so by relying on a bigger number of coordinates, the work of the sensor can become more smooth. Further work might also include changing the thickness of the walls of the silicon body as well as changing its shape to half-sphere. 

![10](https://user-images.githubusercontent.com/67557966/121361273-f5044400-c956-11eb-81e3-28692b51afba.jpg)
![11](https://user-images.githubusercontent.com/67557966/121361277-f59cda80-c956-11eb-8fab-287a4b271927.jpg)

## Chapter 4: Visualisation in Augmented Reality
### 4.1 Introduction
The fourth industrial revolution influenced the fact that more and more companies begin to introduce robotic systems into their production, thereby automating the process. It significantly affects production speed and has a positive effect on overall performance [7]. Furthermore, such a solution eliminates any possible risks related to the presence of a person in dangerous areas, where the robot can operate. In such cases, the operator could use various devices, such as augmented/mixed reality (AR/VR) head-mounted display or smart glasses, in order to remotely control the manipulator.

The usage of augmented or mixed reality devices in production helps to significantly facilitate work in hard-to-reach places, thereunto has the ability to visualize the operator’s intended action before execution in order to observe possible risks and take appropriate measures to avoid them.

During hiring, staff preparation can be greatly facilitated due to the application of AR/MR devices. After a few lessons, employees will be able to learn how to control the manipulator in real life. Moreover, during the action planning, it will be possible to examine the trajectory of movement and possible collisions on the way, as well as display the force vector when working with various objects.

The main purpose of this chapter is to make a connection for controlling the manipulator by using the Unity, ROS and corresponding libraries, as well as visualizing direct contact with the object.

### 4.2 Background
In the work of Ostanin et al. (2020), authors followed an aim to come up with a convenient way to perform different tasks by using manipulators together with a Mixed Reality headset in an industry, where there are many dangerous and risky situations, as well as for robot arms’ operation in places, that are hard to reach [7]. Additionally, they wanted to propose a useful way to control the robot, namely ”Programming By Demonstration” (PbD), where the user does not need to have sufficient technical knowledge, which results in allowing less qualified employees to use the equipment. Finally, a combination of these technologies will open new gates of opportunities for HRI development.

By connecting ROS to Unity together with HoloLens mixed reality headset, the authors were able to import URDF (Universal Robot Description File) models of manipulators and link a real and a virtual robot, while the user can start visualization of the upcoming process in order to observe the trajectory of movement and see the possible obstacles on its way, as well as to make scaling for more comfortable path settings. In order to avoid obstacles, algorithms based on Rapidly-exploring Random Tree (RRT) and A* were used. Furthermore, in order to determine the robot in space, the Jarvis, RANSAC, DBSCAN and ICP algorithms were used, which calculates the approximate location of the manipulator by looking for robot-like objects, and then defines its position. The algorithms’ average running time is 23.1 seconds. Besides that, there is an error in determining the position and orientation which are equal to 9 mm and 3.1 degrees, respectively. The error can be caused by the presence of several objects similar to the manipulator in the scene. In addition, due to scaling, it is possible to increase the accuracy of the path setting from 1-2 cm to 0.5 cm [7]. Due to the usage of HoloLens, the ”Pick and Place” process becomes simpler and the final result with possible risks can be observed immediately. Thus, it is very beneficial to use Mixed Reality devices, as it reduces the number of errors due to virtual simulation and speeds up the program writing.

The main idea of integrating Mixed Reality in operating with manipulators was taken from the authors’ previous work [8], however, in new research work, they made several significant improvements, such as (i) finding and attaching robot in space (ii) avoiding obstacles (iii) scaling in order to improve accuracy in path planning. Therewith, all features were tested with two robots at once: both KUKA iiwa 14 and UR10e. Thus, in this paper, the authors concentrated on user-friendliness to significantly facilitate the working process [7]. Another work, written by Rosen et al. argues that usage of Mixed Reality devices could positively affect efficiency since in that way it can increase accuracy and decrease overall time to accomplish the intended actions due to an experiment conducted among 32 participants [9].

### 4.3 Methodology
### 4.3.1 Functionality
In order to control the manipulator by haptic device and observe the physical contact with the object that the robot touches, it is necessary to send data from sensors to the main computer with installed Unity software from which the operations will be performed. For visualization and image transmission to HoloLens 1st generation headset and communication between ROS to Unity, the Unity Robotics Hub repository, Vuforia Engine, Mixed Reality Toolkit (MRTK) as well as Franka Emika robot’s URDF model were used. The way of how the whole scheme operates described in Figure 4.1.

![12](https://user-images.githubusercontent.com/67557966/121361958-8bd10080-c957-11eb-8c71-6d66022e44e1.jpg)

### 4.3.2 Manipulator control by haptic device
Franka Emika can be controlled directly from a computer with ROS or by using its own interface called Desk, where it is possible to create different commands without coding. Nevertheless, this project proposes a new way to control the robot by using a haptic device described in the 1st chapter. To accomplish this task, it is necessary to receive data from the haptic device and transfer it to the force controller script of Franka Emika. It will allow controlling the robot, speed and movement’s direction of which will depend directly on the force applied by the user. Yet, the manipulator can move down or up along the z-axis, while the results are published in the terminal window on a computer with installed ROS. The reason why the robot only moves along one axis is that the applied force vector will only be displayed along the z-axis from the event-based camera data. All these processes are visualized in the HoloLens headset. In other words, all movements of the real robot are coincided with the virtual model and transmitted directly to the glasses in real-time.

### 4.3.3 Visualization
For the robot’s movement visualization, a computer with Unity software was used, where Vuforia Engine, Mixed Reality Toolkit, as well as URDF Importer packages are already installed on it.

***URDF Importer***

First of all, it’s required to import Franka Emika’s model into the Unity game engine. Due to the usage of URDF importer, an Articulation Body is created for each of the child objects of a panda, which automatically establishes restrictions for joints. This allows the joints of a manipulator to avoid any collisions between each other.







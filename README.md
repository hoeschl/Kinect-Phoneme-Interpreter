Kinect Sign Language
====================

A sign language is a language which uses manual communication and body language to convey meaning, as opposed to acoustically conveyed sound patterns. This can involve simultaneously combining hand shapes, orientation and movement of the hands, arms or body, and facial expressions to fluidly express a speaker's thoughts. Wherever communities of deaf people exist, sign languages have been developed. Signing is not only used by the deaf, it is also used by people who can hear, but cannot physically speak.

The goal of this project consists developing an automatic Kinect Phoneme Interpreter using the data provided by the Microsoft Kinect XBOX 360 camera.

This is an extension of kinect-sign-language by Svilen Popov (https://github.com/svil4ok/kinect-sign-language). This removes all previous signs and adds 38 new gestures that are linked to phonemes in English. Sections of the code were altered to properly run the gestures added but the program largely remains the same from Popov's version.

System Requirements
-----------

Supported Operating System:
  - Windows 7, Windows 8, Windows 8.1

Your computer must have the following minimum capabilities:
  - 64-bit (x64) processor
  - Dual-core 2.66-GHz or faster processor
  - Dedicated USB 2.0 bus
  - 2 GB RAM
  - A Microsoft Kinect (Model 1414)

![Microsoft Xbox 360 Kinect Model 1414](http://i.imgur.com/EMkejfZ.jpg)

Software requirements:
  - Visual Studio 2012 or newer
  - [.NET Framework 4.5]
  - [Kinect for Windows SDK 1.8]
  - [Kinect for Windows Developer Toolkit v1.8]

[.NET Framework 4.5]:http://www.microsoft.com/en-us/download/details.aspx?id=30653
[Kinect for Windows SDK 1.8]:http://www.microsoft.com/en-us/download/details.aspx?id=40278
[Kinect for Windows Developer Toolkit v1.8]:http://www.microsoft.com/en-us/download/details.aspx?id=40276

To Download and Run
-----------
To download this tool, you need to first download .NET Framework 4.5, Kinect for Windows SDK 1.8, and Kinect for Windows Developer Toolkit v1.8 listed above. This is able to be run on computers running Windows 7, Windows 8, Windows 8.1, and Windows Embedded Standard 7.  Visual Studio 2012 or newer is needed to run the software (https://www.visualstudio.com/downloads/). A Kinect needs an AC adapter power supply USB cable cord to be connected to the laptop to have power. The main program of the tool is opened in Visual Studio and is named KinectSignLangauge. Once opened, hit the start button and it will begin to debug. Once finished, it will open a new window named Kinect Sign Language :: beta. This window displays the Kinect using skeletal tracking in real-time. When it recognizes a word, it will display the word at the bottom of the screen. When a new word is recognized, it will replace the previously recognized word with the new one. 

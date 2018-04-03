﻿namespace KSL.Gestures.Segments
{
    using KSL.Gestures.Core;
    using Microsoft.Kinect;
    using System;

	// car. Conflicts with others and is very touchy.
    public class arSegment1 : IGesturesSegment
    {
        public GesturePartResult CheckGesture(Skeleton skeleton)
        {
            if (skeleton.Joints[JointType.ElbowLeft].Position.X < skeleton.Joints[JointType.ShoulderLeft].Position.X &&
                skeleton.Joints[JointType.ElbowRight].Position.X > skeleton.Joints[JointType.ShoulderRight].Position.X)
            {
                if (skeleton.Joints[JointType.ElbowLeft].Position.Y > skeleton.Joints[JointType.ShoulderLeft].Position.Y &&
                    skeleton.Joints[JointType.ElbowRight].Position.Y > skeleton.Joints[JointType.ShoulderRight].Position.Y)
                {
                    if (skeleton.Joints[JointType.ElbowLeft].Position.Y > skeleton.Joints[JointType.HandLeft].Position.Y &&
                        skeleton.Joints[JointType.ElbowRight].Position.Y > skeleton.Joints[JointType.HandRight].Position.Y)
                    {
                        return GesturePartResult.Succeed;
                    }

                    return GesturePartResult.Pausing;
                }

                return GesturePartResult.Fail;
            }

            return GesturePartResult.Fail;
        }
    }
}

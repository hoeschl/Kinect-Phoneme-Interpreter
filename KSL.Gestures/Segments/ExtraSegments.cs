namespace KSL.Gestures.Segments
{
    using KSL.Gestures.Core;
    using Microsoft.Kinect;
    using System;

	// Left hand is left of left shoulder, right hand is left of left shoulder. Left hand is above left shoulder and
	// right hand is above left shoulder. Left hand is above left elbow and right hand is above right elbow.
    public class nSegment1 : IGesturesSegment
    {
        public GesturePartResult CheckGesture(Skeleton skeleton)
        {
            if (skeleton.Joints[JointType.HandLeft].Position.X < skeleton.Joints[JointType.ShoulderLeft].Position.X &&
                skeleton.Joints[JointType.HandRight].Position.X < skeleton.Joints[JointType.ShoulderLeft].Position.X)
            {
                if (skeleton.Joints[JointType.HandLeft].Position.Y > skeleton.Joints[JointType.ShoulderLeft].Position.Y &&
                    skeleton.Joints[JointType.HandRight].Position.Y > skeleton.Joints[JointType.ShoulderLeft].Position.Y)
                {
                    if (skeleton.Joints[JointType.HandLeft].Position.X > skeleton.Joints[JointType.ElbowLeft].Position.X &&
                        skeleton.Joints[JointType.HandRight].Position.X > skeleton.Joints[JointType.ElbowRight].Position.X)
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


namespace KSL.Gestures.Segments
{
    using KSL.Gestures.Core;
    using Microsoft.Kinect;
    using System;

	// Left hand is right of right shoulder, right hand is right of right shoulder. Left hand is above right shoulder and
	// right hand is above right shoulder. Left hand is above left elbow and right hand is above right elbow.
    public class nSegment1 : IGesturesSegment
    {
        public GesturePartResult CheckGesture(Skeleton skeleton)
        {
            if (skeleton.Joints[JointType.HandLeft].Position.X > skeleton.Joints[JointType.ShoulderRight].Position.X &&
                skeleton.Joints[JointType.HandRight].Position.X > skeleton.Joints[JointType.ShoulderRight].Position.X)
            {
                if (skeleton.Joints[JointType.HandLeft].Position.Y > skeleton.Joints[JointType.ShoulderRight].Position.Y &&
                    skeleton.Joints[JointType.HandRight].Position.Y > skeleton.Joints[JointType.ShoulderRight].Position.Y)
                {
                    if (skeleton.Joints[JointType.HandLeft].Position.X > skeleton.Joints[JointType.ElbowLeft].Position.X &&
                        skeleton.Joints[JointType.HandRight].Position.X > skeleton.Joints[JointType.ElbowRight].Position.X)
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













namespace KSL.Gestures.Segments
{
    using KSL.Gestures.Core;
    using Microsoft.Kinect;
    using System;

	// Left hand is right of right shoulder, right hand is right of right shoulder. Left hand is below right shoulder and
	// right hand is below right shoulder. Left hand is below left elbow and right hand is below right elbow.
    public class nSegment1 : IGesturesSegment
    {
        public GesturePartResult CheckGesture(Skeleton skeleton)
        {
            if (skeleton.Joints[JointType.HandLeft].Position.X > skeleton.Joints[JointType.ShoulderRight].Position.X &&
                skeleton.Joints[JointType.HandRight].Position.X > skeleton.Joints[JointType.ShoulderRight].Position.X)
            {
                if (skeleton.Joints[JointType.HandLeft].Position.Y < skeleton.Joints[JointType.ShoulderRight].Position.Y &&
                    skeleton.Joints[JointType.HandRight].Position.Y < skeleton.Joints[JointType.ShoulderRight].Position.Y)
                {
                    if (skeleton.Joints[JointType.HandLeft].Position.X < skeleton.Joints[JointType.ElbowLeft].Position.X &&
                        skeleton.Joints[JointType.HandRight].Position.X < skeleton.Joints[JointType.ElbowRight].Position.X)
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












namespace KSL.Gestures.Segments
{
    using KSL.Gestures.Core;
    using Microsoft.Kinect;
    using System;

	// Left hand is left of right shoulder, right hand is left of right shoulder. Left hand is below right shoulder and
	// right hand is below right shoulder. Left hand is below left elbow and right hand is below right elbow.
    public class nSegment1 : IGesturesSegment
    {
        public GesturePartResult CheckGesture(Skeleton skeleton)
        {
            if (skeleton.Joints[JointType.HandLeft].Position.X < skeleton.Joints[JointType.ShoulderRight].Position.X &&
                skeleton.Joints[JointType.HandRight].Position.X < skeleton.Joints[JointType.ShoulderRight].Position.X)
            {
                if (skeleton.Joints[JointType.HandLeft].Position.Y < skeleton.Joints[JointType.ShoulderRight].Position.Y &&
                    skeleton.Joints[JointType.HandRight].Position.Y < skeleton.Joints[JointType.ShoulderRight].Position.Y)
                {
                    if (skeleton.Joints[JointType.HandLeft].Position.X < skeleton.Joints[JointType.ElbowLeft].Position.X &&
                        skeleton.Joints[JointType.HandRight].Position.X < skeleton.Joints[JointType.ElbowRight].Position.X)
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






namespace KSL.Gestures.Segments
{
    using KSL.Gestures.Core;
    using Microsoft.Kinect;
    using System;

	// Left hand is left of right shoulder, right hand is right of right shoulder. Left hand is below right shoulder and
	// right hand is above right shoulder. Left hand is below left elbow and right hand is above right elbow.
    public class nSegment1 : IGesturesSegment
    {
        public GesturePartResult CheckGesture(Skeleton skeleton)
        {
            if (skeleton.Joints[JointType.HandLeft].Position.X < skeleton.Joints[JointType.ShoulderRight].Position.X &&
                skeleton.Joints[JointType.HandRight].Position.X < skeleton.Joints[JointType.ShoulderRight].Position.X)
            {
                if (skeleton.Joints[JointType.HandLeft].Position.Y < skeleton.Joints[JointType.ShoulderRight].Position.Y &&
                    skeleton.Joints[JointType.HandRight].Position.Y > skeleton.Joints[JointType.ShoulderRight].Position.Y)
                {
                    if (skeleton.Joints[JointType.HandLeft].Position.X < skeleton.Joints[JointType.ElbowLeft].Position.X &&
                        skeleton.Joints[JointType.HandRight].Position.X > skeleton.Joints[JointType.ElbowRight].Position.X)
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











namespace KSL.Gestures.Segments
{
    using KSL.Gestures.Core;
    using Microsoft.Kinect;
    using System;

	// Left hand is right of right shoulder, right left is right of right shoulder. Left hand is below right shoulder and
	// right hand is above right shoulder. Left hand is below left elbow and right hand is above right elbow.
    public class nSegment1 : IGesturesSegment
    {
        public GesturePartResult CheckGesture(Skeleton skeleton)
        {
            if (skeleton.Joints[JointType.HandLeft].Position.X > skeleton.Joints[JointType.ShoulderRight].Position.X &&
                skeleton.Joints[JointType.HandRight].Position.X > skeleton.Joints[JointType.ShoulderRight].Position.X)
            {
                if (skeleton.Joints[JointType.HandLeft].Position.Y < skeleton.Joints[JointType.ShoulderRight].Position.Y &&
                    skeleton.Joints[JointType.HandRight].Position.Y > skeleton.Joints[JointType.ShoulderRight].Position.Y)
                {
                    if (skeleton.Joints[JointType.HandLeft].Position.X < skeleton.Joints[JointType.ElbowLeft].Position.X &&
                        skeleton.Joints[JointType.HandRight].Position.X > skeleton.Joints[JointType.ElbowRight].Position.X)
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

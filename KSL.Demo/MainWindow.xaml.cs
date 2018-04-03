namespace KSL.Demo
{
    using KSL.Gestures.Classifier;
    using KSL.Gestures.Core;
    using KSL.Gestures.Logger;
    using KSL.Gestures.Segments;
    using Microsoft.Kinect;
    using Microsoft.Kinect.Toolkit;
    using Microsoft.Samples.Kinect.WpfViewers;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Text;
    using System.Timers;
    using System.Windows;
    using System.Windows.Data;

    public partial class MainWindow : Window, INotifyPropertyChanged
    {
        #region "Declaration"

        private KSLConfig config = new KSLConfig();
        private readonly KinectSensorChooser sensorChooser = new KinectSensorChooser();
        private Skeleton[] skeletons = new Skeleton[0];
        private GesturesController gestureController;

        public event PropertyChangedEventHandler PropertyChanged;
        
        Classifier classifier = Classifier.getInstance;
        private Logger logger = Logger.getInstance;

        private string gestureSentence;
        private string gestureBuilder;
        Timer startStopTimer;
        private bool isNewSentence = false;

        #endregion

        #region "Constructor"

        public MainWindow()
        {
            DataContext = this;
            InitializeComponent();

            startStopTimer = new Timer(2000);
            startStopTimer.Elapsed += new ElapsedEventHandler(startStopTimer_Elapsed);

            classifier.init();
            InitializeKinect();
        }

        #endregion

        #region "Initialize Kinect"

        private void InitializeKinect()
        {
            // initialize the Kinect sensor manager
            KinectSensorManager = new KinectSensorManager();
            KinectSensorManager.KinectSensorChanged += this.KinectSensorChanged;

            // locate an available sensor
            sensorChooser.Start();

            // bind chooser's sensor value to the local sensor manager
            var kinectSensorBinding = new Binding("Kinect") { Source = this.sensorChooser };
            BindingOperations.SetBinding(this.KinectSensorManager, KinectSensorManager.KinectSensorProperty, kinectSensorBinding);
        }

        private void KinectSensorChanged(object sender, KinectSensorManagerEventArgs<KinectSensor> args)
        {
            if (null != args.OldValue)
                UninitializeKinectServices(args.OldValue);

            if (null != args.NewValue)
                InitializeKinectServices(KinectSensorManager, args.NewValue);
        }

        private void InitializeKinectServices(KinectSensorManager kinectSensorManager, KinectSensor sensor)
        {
            kinectSensorManager.ColorFormat = config.colorImageFormat;
            kinectSensorManager.ColorStreamEnabled = true;

            kinectSensorManager.DepthStreamEnabled = true;

            kinectSensorManager.TransformSmoothParameters = config.transformSmoothParameters;

            sensor.SkeletonFrameReady += OnSkeletonFrameReady;
            kinectSensorManager.SkeletonStreamEnabled = true;

            kinectSensorManager.KinectSensorEnabled = true;

            if (!kinectSensorManager.KinectSensorAppConflict)
            {
                gestureController = new GesturesController();
                gestureController.GestureRecognized += OnGestureRecognized;

                RegisterGestures();
            }
        }

        private void UninitializeKinectServices(KinectSensor sensor)
        {
            sensor.SkeletonFrameReady -= OnSkeletonFrameReady;
            gestureController.GestureRecognized -= OnGestureRecognized;
        }

        private void OnSkeletonFrameReady(object sender, SkeletonFrameReadyEventArgs e)
        {
            using (SkeletonFrame frame = e.OpenSkeletonFrame())
            {
                if (frame == null)
                    return;

                // resize the skeletons array if needed
                if (skeletons.Length != frame.SkeletonArrayLength)
                    skeletons = new Skeleton[frame.SkeletonArrayLength];

                // get the skeleton data
                frame.CopySkeletonDataTo(skeletons);

                foreach (var skeleton in skeletons)
                {
                    // skip the skeleton if it is not being tracked
                    if (skeleton.TrackingState != SkeletonTrackingState.Tracked)
                        continue;

                    // update the gesture controller
                    gestureController.UpdateAllGestures(skeleton);
                }
            }
        }

        public static readonly DependencyProperty KinectSensorManagerProperty = DependencyProperty.Register
        (
            "KinectSensorManager",
            typeof(KinectSensorManager),
            typeof(MainWindow),
            new PropertyMetadata(null)
        );

        public KinectSensorManager KinectSensorManager
        {
            get { return GetValue(KinectSensorManagerProperty) as KinectSensorManager; }
            set { SetValue(KinectSensorManagerProperty, value); }
        }

        #endregion

        #region "Gestures - Register, Recognize"

        private void RegisterGestures()
        {
            // Word: d
            IGesturesSegment[] dSegments = new IGesturesSegment[4];
            dSegment1 dSegment1 = new dSegment1();
            dSegments[0] = dSegment1;
            dSegments[1] = dSegment1;
            dSegments[2] = dSegment1;
            dSegments[3] = dSegment1;
            gestureController.AddGesture("d", dSegments);
			
			// Word: f
            IGesturesSegment[] fSegments = new IGesturesSegment[4];
            fSegment1 fSegment1 = new fSegment1();
            fSegments[0] = fSegment1;
            fSegments[1] = fSegment1;
            fSegments[2] = fSegment1;
            fSegments[3] = fSegment1;
            gestureController.AddGesture("f", fSegments);
			
			// Word: g
            IGesturesSegment[] gSegments = new IGesturesSegment[4];
            gSegment1 gSegment1 = new gSegment1();
            gSegments[0] = gSegment1;
            gSegments[1] = gSegment1;
            gSegments[2] = gSegment1;
            gSegments[3] = gSegment1;
            gestureController.AddGesture("g", gSegments);
			
			// Word: h
            IGesturesSegment[] hSegments = new IGesturesSegment[4];
            hSegment1 hSegment1 = new hSegment1();
            hSegments[0] = hSegment1;
            hSegments[1] = hSegment1;
            hSegments[2] = hSegment1;
            hSegments[3] = hSegment1;
            gestureController.AddGesture("h", hSegments);
			
			// Word: j
            IGesturesSegment[] jSegments = new IGesturesSegment[4];
            jSegment1 jSegment1 = new jSegment1();
            jSegments[0] = jSegment1;
            jSegments[1] = jSegment1;
            jSegments[2] = jSegment1;
            jSegments[3] = jSegment1;
            gestureController.AddGesture("j", jSegments);
			
			// Word: k
            IGesturesSegment[] kSegments = new IGesturesSegment[4];
            kSegment1 kSegment1 = new kSegment1();
            kSegments[0] = kSegment1;
            kSegments[1] = kSegment1;
            kSegments[2] = kSegment1;
            kSegments[3] = kSegment1;
            gestureController.AddGesture("k", kSegments);
			
			// Word: l
            IGesturesSegment[] lSegments = new IGesturesSegment[4];
            lSegment1 lSegment1 = new lSegment1();
            lSegments[0] = lSegment1;
            lSegments[1] = lSegment1;
            lSegments[2] = lSegment1;
            lSegments[3] = lSegment1;
            gestureController.AddGesture("l", lSegments);
			
			// Word: m
            IGesturesSegment[] mSegments = new IGesturesSegment[4];
            mSegment1 mSegment1 = new mSegment1();
            mSegments[0] = mSegment1;
            mSegments[1] = mSegment1;
            mSegments[2] = mSegment1;
            mSegments[3] = mSegment1;
            gestureController.AddGesture("m", mSegments);
			
			// Word: n
            IGesturesSegment[] nSegments = new IGesturesSegment[4];
            nSegment1 nSegment1 = new nSegment1();
            nSegments[0] = nSegment1;
            nSegments[1] = nSegment1;
            nSegments[2] = nSegment1;
            nSegments[3] = nSegment1;
            gestureController.AddGesture("n", nSegments);

			// Word: ng
            IGesturesSegment[] ngSegments = new IGesturesSegment[4];
            ngSegment1 ngSegment1 = new ngSegment1();
            ngSegments[0] = ngSegment1;
            ngSegments[1] = ngSegment1;
            ngSegments[2] = ngSegment1;
            ngSegments[3] = ngSegment1;
            gestureController.AddGesture("ng", ngSegments);
			
			// Word: p
            IGesturesSegment[] pSegments = new IGesturesSegment[4];
            pSegment1 pSegment1 = new pSegment1();
            pSegments[0] = pSegment1;
            pSegments[1] = pSegment1;
            pSegments[2] = pSegment1;
            pSegments[3] = pSegment1;
            gestureController.AddGesture("p", pSegments);
			
			// Word: r
            IGesturesSegment[] rSegments = new IGesturesSegment[4];
            rSegment1 rSegment1 = new rSegment1();
            rSegments[0] = rSegment1;
            rSegments[1] = rSegment1;
            rSegments[2] = rSegment1;
            rSegments[3] = rSegment1;
            gestureController.AddGesture("r", rSegments);
			
			// Word: s
            IGesturesSegment[] sSegments = new IGesturesSegment[4];
            sSegment1 sSegment1 = new sSegment1();
            sSegments[0] = sSegment1;
            sSegments[1] = sSegment1;
            sSegments[2] = sSegment1;
            sSegments[3] = sSegment1;
            gestureController.AddGesture("s", sSegments);
			
			// Word: t
            IGesturesSegment[] tSegments = new IGesturesSegment[4];
            tSegment1 tSegment1 = new tSegment1();
            tSegments[0] = tSegment1;
            tSegments[1] = tSegment1;
            tSegments[2] = tSegment1;
            tSegments[3] = tSegment1;
            gestureController.AddGesture("t", tSegments);
			
			// Word: v
            IGesturesSegment[] vSegments = new IGesturesSegment[4];
            vSegment1 vSegment1 = new vSegment1();
            vSegments[0] = vSegment1;
            vSegments[1] = vSegment1;
            vSegments[2] = vSegment1;
            vSegments[3] = vSegment1;
            gestureController.AddGesture("v", vSegments);
			
			// Word: w
            IGesturesSegment[] wSegments = new IGesturesSegment[4];
            wSegment1 wSegment1 = new wSegment1();
            wSegments[0] = wSegment1;
            wSegments[1] = wSegment1;
            wSegments[2] = wSegment1;
            wSegments[3] = wSegment1;
            gestureController.AddGesture("w", wSegments);
			
			// Word: y
            IGesturesSegment[] ySegments = new IGesturesSegment[4];
            ySegment1 ySegment1 = new ySegment1();
            ySegments[0] = ySegment1;
            ySegments[1] = ySegment1;
            ySegments[2] = ySegment1;
            ySegments[3] = ySegment1;
            gestureController.AddGesture("y", ySegments);
			
			// Word: z
            IGesturesSegment[] zSegments = new IGesturesSegment[4];
            zSegment1 zSegment1 = new zSegment1();
            zSegments[0] = zSegment1;
            zSegments[1] = zSegment1;
            zSegments[2] = zSegment1;
            zSegments[3] = zSegment1;
            gestureController.AddGesture("z", zSegments);
			
			// Word: zh
            IGesturesSegment[] zhSegments = new IGesturesSegment[4];
            zhSegment1 zhSegment1 = new zhSegment1();
            zhSegments[0] = zhSegment1;
            zhSegments[1] = zhSegment1;
            zhSegments[2] = zhSegment1;
            zhSegments[3] = zhSegment1;
            gestureController.AddGesture("zh", zhSegments);
			
			// Word: ch
            IGesturesSegment[] chSegments = new IGesturesSegment[4];
            chSegment1 chSegment1 = new chSegment1();
            chSegments[0] = chSegment1;
            chSegments[1] = chSegment1;
            chSegments[2] = chSegment1;
            chSegments[3] = chSegment1;
            gestureController.AddGesture("ch", chSegments);
			
			// Word: sh
            IGesturesSegment[] shSegments = new IGesturesSegment[4];
            shSegment1 shSegment1 = new shSegment1();
            shSegments[0] = shSegment1;
            shSegments[1] = shSegment1;
            shSegments[2] = shSegment1;
            shSegments[3] = shSegment1;
            gestureController.AddGesture("sh", shSegments);
			
			// Word: th
            IGesturesSegment[] thSegments = new IGesturesSegment[4];
            thSegment1 thSegment1 = new thSegment1();
            thSegments[0] = thSegment1;
            thSegments[1] = thSegment1;
            thSegments[2] = thSegment1;
            thSegments[3] = thSegment1;
            gestureController.AddGesture("th", thSegments);
			
			// Word: a
            IGesturesSegment[] aSegments = new IGesturesSegment[4];
            aSegment1 aSegment1 = new aSegment1();
            aSegments[0] = aSegment1;
            aSegments[1] = aSegment1;
            aSegments[2] = aSegment1;
            aSegments[3] = aSegment1;
            gestureController.AddGesture("a", aSegments);
			
			// Word: e
            IGesturesSegment[] eSegments = new IGesturesSegment[4];
            eSegment1 eSegment1 = new eSegment1();
            eSegments[0] = eSegment1;
            eSegments[1] = eSegment1;
            eSegments[2] = eSegment1;
            eSegments[3] = eSegment1;
            gestureController.AddGesture("e", eSegments);
			
			// Word: i
            IGesturesSegment[] iSegments = new IGesturesSegment[4];
            iSegment1 iSegment1 = new iSegment1();
            iSegments[0] = iSegment1;
            iSegments[1] = iSegment1;
            iSegments[2] = iSegment1;
            iSegments[3] = iSegment1;
            gestureController.AddGesture("i", iSegments);
			
			// Word: o
            IGesturesSegment[] oSegments = new IGesturesSegment[4];
            oSegment1 oSegment1 = new oSegment1();
            oSegments[0] = oSegment1;
            oSegments[1] = oSegment1;
            oSegments[2] = oSegment1;
            oSegments[3] = oSegment1;
            gestureController.AddGesture("o", oSegments);
			
			// Word: u
            IGesturesSegment[] uSegments = new IGesturesSegment[4];
            uSegment1 uSegment1 = new uSegment1();
            uSegments[0] = uSegment1;
            uSegments[1] = uSegment1;
            uSegments[2] = uSegment1;
            uSegments[3] = uSegment1;
            gestureController.AddGesture("u", uSegments);
			
			// Word: oo
            IGesturesSegment[] ooSegments = new IGesturesSegment[4];
            ooSegment1 ooSegment1 = new ooSegment1();
            ooSegments[0] = ooSegment1;
            ooSegments[1] = ooSegment1;
            ooSegments[2] = ooSegment1;
            ooSegments[3] = ooSegment1;
            gestureController.AddGesture("oo", ooSegments);
			
			// Word: ai
            IGesturesSegment[] aiSegments = new IGesturesSegment[4];
            aiSegment1 aiSegment1 = new aiSegment1();
            aiSegments[0] = aiSegment1;
            aiSegments[1] = aiSegment1;
            aiSegments[2] = aiSegment1;
            aiSegments[3] = aiSegment1;
            gestureController.AddGesture("ai", aiSegments);
			
			// Word: ee
            IGesturesSegment[] eeSegments = new IGesturesSegment[4];
            eeSegment1 eeSegment1 = new eeSegment1();
            eeSegments[0] = eeSegment1;
            eeSegments[1] = eeSegment1;
            eeSegments[2] = eeSegment1;
            eeSegments[3] = eeSegment1;
            gestureController.AddGesture("ee", eeSegments);
			
			// Word: oa
            IGesturesSegment[] oaSegments = new IGesturesSegment[4];
            oaSegment1 oaSegment1 = new oaSegment1();
            oaSegments[0] = oaSegment1;
            oaSegments[1] = oaSegment1;
            oaSegments[2] = oaSegment1;
            oaSegments[3] = oaSegment1;
            gestureController.AddGesture("oa", oaSegments);
			
			// Word: oi
            IGesturesSegment[] oiSegments = new IGesturesSegment[4];
            oiSegment1 oiSegment1 = new oiSegment1();
            oiSegments[0] = oiSegment1;
            oiSegments[1] = oiSegment1;
            oiSegments[2] = oiSegment1;
            oiSegments[3] = oiSegment1;
            gestureController.AddGesture("oi", oiSegments);
			
			// Word: ow
            IGesturesSegment[] owSegments = new IGesturesSegment[4];
            owSegment1 owSegment1 = new owSegment1();
            owSegments[0] = owSegment1;
            owSegments[1] = owSegment1;
            owSegments[2] = owSegment1;
            owSegments[3] = owSegment1;
            gestureController.AddGesture("ow", owSegments);
			
			// Word: er
            IGesturesSegment[] erSegments = new IGesturesSegment[4];
            erSegment1 erSegment1 = new erSegment1();
            erSegments[0] = erSegment1;
            erSegments[1] = erSegment1;
            erSegments[2] = erSegment1;
            erSegments[3] = erSegment1;
            gestureController.AddGesture("er", erSegments);
			
			// Word: eir
            IGesturesSegment[] eirSegments = new IGesturesSegment[4];
            eirSegment1 eirSegment1 = new eirSegment1();
            eirSegments[0] = eirSegment1;
            eirSegments[1] = eirSegment1;
            eirSegments[2] = eirSegment1;
            eirSegments[3] = eirSegment1;
            gestureController.AddGesture("eir", eirSegments);
			
			// Word: ar
            IGesturesSegment[] arSegments = new IGesturesSegment[4];
            arSegment1 arSegment1 = new arSegment1();
            arSegments[0] = arSegment1;
            arSegments[1] = arSegment1;
            arSegments[2] = arSegment1;
            arSegments[3] = arSegment1;
            gestureController.AddGesture("ar", arSegments);
			
			// Word: ir
            IGesturesSegment[] irSegments = new IGesturesSegment[4];
            irSegment1 irSegment1 = new irSegment1();
            irSegments[0] = irSegment1;
            irSegments[1] = irSegment1;
            irSegments[2] = irSegment1;
            irSegments[3] = irSegment1;
            gestureController.AddGesture("ir", irSegments);
			
            // Word: b
            IGesturesSegment[] bSegments = new IGesturesSegment[10];
            bSegment1 bSegment1 = new bSegment1();
            bSegments[0] = bSegment1;
            bSegments[1] = bSegment1;
            bSegments[2] = bSegment1;
            bSegments[3] = bSegment1;
            bSegments[4] = bSegment1;
            bSegments[5] = bSegment1;
            bSegments[6] = bSegment1;
            bSegments[7] = bSegment1;
            bSegments[8] = bSegment1;
            bSegments[9] = bSegment1;
            gestureController.AddGesture("b", bSegments);
        }

        private void OnGestureRecognized(object sender, GesturesEventArgs e)
        {
            switch (e.GestureName)
            {
                case "d":
                    display(WordsEnum.d);
                    break;
                case "b":
                    display(WordsEnum.b);
                    break;
				case "f":
                    display(WordsEnum.f);
                    break;
				case "g":
                    display(WordsEnum.g);
                    break;
				case "h":
                    display(WordsEnum.h);
                    break;
				case "j":
                    display(WordsEnum.j);
                    break;
				case "k":
                    display(WordsEnum.k);
					break;
				case "l":
                    display(WordsEnum.l);
                    break;
				case "m":
                    display(WordsEnum.m);
                    break;
				case "n":
                    display(WordsEnum.n);
                    break;
				case "ng":
                    display(WordsEnum.ng);
                    break;
				case "p":
                    display(WordsEnum.p);
                    break;
				case "r":
                    display(WordsEnum.r);
                    break;
				case "s":
                    display(WordsEnum.s);
                    break;
				case "t":
                    display(WordsEnum.t);
                    break;
				case "v":
                    display(WordsEnum.v);
                    break;
				case "w":
                    display(WordsEnum.w);
                    break;
				case "y":
                    display(WordsEnum.y);
                    break;
				case "z":
                    display(WordsEnum.z);
                    break;
				case "zh":
                    display(WordsEnum.zh);
                    break;
				case "ch":
                    display(WordsEnum.ch);
                    break;
				case "sh":
                    display(WordsEnum.sh);
                    break;
				case "th":
                    display(WordsEnum.th);
                    break;
				case "a":
                    display(WordsEnum.a);
                    break;
				case "e":
                    display(WordsEnum.e);
                    break;
				case "i":
                    display(WordsEnum.i);
                    break;
				case "o":
                    display(WordsEnum.o);
                    break;
				case "u":
                    display(WordsEnum.u);
                    break;
				case "oo":
                    display(WordsEnum.oo);
                    break;
				case "ai":
                    display(WordsEnum.ai);
                    break;
				case "ee":
                    display(WordsEnum.ee);
                    break;
				case "oa":
                    display(WordsEnum.oa);
                    break;
				case "oi":
                    display(WordsEnum.oi);
                    break;
				case "ow":
                    display(WordsEnum.ow);
                    break;
				case "er":
                    display(WordsEnum.er);
                    break;
				case "eir":
                    display(WordsEnum.eir);
                    break;
				case "ar":
                    display(WordsEnum.ar);
                    break;
				case "ir":
                    display(WordsEnum.ir);
                    break;
                default:
                    break;
            }
        }

        #endregion

        #region "Display text"

        private void reset()
        {
            classifier.reset();
        }

        private void display(WordsEnum word)
        {
            classifier.addCode((int) word);
            string sentence = classifier.findSentence();
            List<int> sentenceBuilder = classifier.getSentenceBuilder();

            if (!isNewSentence)
            {
                if (sentenceBuilder.Count > 1 && !String.IsNullOrEmpty(sentence))
                {
                    isNewSentence = true;
                    startStopTimer.Start();
                    StringBuilder sb = new StringBuilder();
                    GestureBuilder = String.Empty;
                    foreach (int wordCode in sentenceBuilder)
                    {
                        sb.Append(Enum.GetName(typeof(WordsEnum), wordCode));
                        sb.Append(" ● ");
                    }
                    sb.Length = sb.Length - 3;
                    GestureBuilder = sb.ToString();
                    GestureSentence = sentence;
                }
                else
                {
                    GestureSentence = String.Empty;
                    GestureBuilder = Enum.GetName(typeof(WordsEnum), word);
                }
            }
        }

        public String GestureSentence
        {
            get { return gestureSentence; }

            private set
            {
                if (gestureSentence == value)
                    return;

                gestureSentence = value;

                if (this.PropertyChanged != null)
                    PropertyChanged(this, new PropertyChangedEventArgs("GestureSentence"));
            }
        }

        public String GestureBuilder
        {
            get { return gestureBuilder; }

            private set
            {
                if (gestureBuilder == value)
                    return;

                gestureBuilder = value;

                if(this.PropertyChanged != null)
                    PropertyChanged(this, new PropertyChangedEventArgs("GestureBuilder"));
            }
        }

        private void startStopTimer_Elapsed(object sender, ElapsedEventArgs e)
        {
            startStopTimer.Stop();
            this.isNewSentence = false;
        }

        #endregion
    }
}

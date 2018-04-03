﻿namespace KSL.Gestures.Classifier
{
    using KSL.Gestures.Logger;
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public sealed class Classifier
    {
        #region "Declarations"

        private static readonly Classifier instance = new Classifier();

        private List<int> sentenceBuilder = new List<int>();

        private int currentWordIndex = 0;

        private List<int> notMatchList = new List<int>();

        private string foundSentence = String.Empty;

        private List<SentenceStructure> sentencesDictionary = new List<SentenceStructure>();

        private bool areThereMatches = false;

        #endregion

        #region "Constructors"

        static Classifier() { }

        private Classifier() { }

        #endregion

        public static Classifier getInstance
        {
            get { return instance; }
        }

        public void init()
        {

        }

        public void addCode(int wordCode)
        {
            if (this.sentenceBuilder.Count > 0 && this.sentenceBuilder[this.sentenceBuilder.Count - 1] == wordCode)
            {
                return;
            }

            this.sentenceBuilder.Add(wordCode);   
        }

        public string findSentence()
        {
            this.foundSentence = String.Empty;

            if (this.sentenceBuilder.Count > 1)
            {

                for (int i = currentWordIndex; i < this.sentenceBuilder.Count; i += 1)
                {
                    areThereMatches = false;

                    foreach (SentenceStructure s in this.sentencesDictionary)
                    {
                        if (this.notMatchList.Contains(s.ID) || this.sentenceBuilder.Count > s.Codes.Count)
                            continue;

                        if (this.sentenceBuilder[i] != s.Codes[i])
                        {
                            this.notMatchList.Add(s.ID);
                            if (!areThereMatches)
                                areThereMatches = false;

                            continue;
                        }

                        if (this.sentenceBuilder.Count == s.Codes.Count && this.sentenceBuilder.SequenceEqual(s.Codes))
                        {
                            this.foundSentence = s.Text;
                            areThereMatches = true;

                            return this.foundSentence;
                        }

                        areThereMatches = true;
                    }

                    if (!this.areThereMatches)
                    {
                        this.foundSentence = String.Empty;
                        this.currentWordIndex = 0;
                        i = currentWordIndex;
                        int temp = sentenceBuilder[sentenceBuilder.Count - 1];
                        this.sentenceBuilder.Clear();
                        this.sentenceBuilder.Add(temp);
                        this.notMatchList.Clear();

                        return findSentence();
                    }

                    if (this.sentenceBuilder.Count > 0)
                        this.currentWordIndex += 1;

                    return String.Empty;
                }
            }

            return String.Empty;
        }

        public bool getAreThereMatches()
        {
            return this.areThereMatches;
        }

        public string getSentence()
        {
            return this.foundSentence;
        }

        public List<int> getSentenceBuilder()
        {
            List<int> temp = new List<int>(this.sentenceBuilder);

            if (!String.IsNullOrEmpty(this.foundSentence))
                this.clear();

            return temp;
        }

        private void clear()
        {
            this.sentenceBuilder.Clear();
            this.notMatchList.Clear();
            this.foundSentence = String.Empty;
            this.currentWordIndex = 0;
        }

        public void reset()
        {
            this.clear();
        }
    }
}

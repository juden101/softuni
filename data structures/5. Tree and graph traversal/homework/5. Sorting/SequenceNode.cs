namespace homework
{
    class SequenceNode
    {
        public SequenceNode(string sequence, int iterationCount)
        {
            this.Sequence = sequence;
            this.IterationCount = iterationCount;
        }

        public string Sequence { get; set; }

        public int IterationCount { get; set; }
    }
}

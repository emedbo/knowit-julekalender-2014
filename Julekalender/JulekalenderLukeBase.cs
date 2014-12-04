namespace Julekalender
{
    public abstract class JulekalenderLukeBase<T> : IJulekalenderLuke<T>
    {
        public abstract T Solve();
        protected abstract int GetNummer();

        public string SolveAndPrint()
        {
            var solution = Solve();

            return "Luke " + GetNummer() + " svar er: " + solution;
        }
    }
}
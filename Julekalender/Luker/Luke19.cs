using System.Diagnostics.CodeAnalysis;

namespace Julekalender.Luker
{
    public class Luke19 : JulekalenderLukeBase<string>
    {
        public override string Solve()
        {
            var str = InputString();
            var max = "";
            for (int i = 0; i < str.Length - 1; i++)
            {
                for (int j = i; j < str.Length; j++)
                {
                    var substr = str.Substring(i, str.Length - j);
                    if (!Utils.IsPalindrom(substr))
                    {
                        continue;
                    }
                    if (substr.Length > max.Length)
                    {
                        max = substr;
                    }
                }
            }
            return max;
        }

        protected override int GetNummer()
        {
            return 19;
        }

        private string InputString()
        {
            return
                "JegtroringenkanleveetheltlivutenkjærlighetMenkjærlighetenharmangeansikterIhøstkomdetutenboksomheterErlikKjærlighetDenbeståravsamtalermedselgereavgatemagasinetsomnåeretablertimangenorskebyerAllehardeenhistorieåfortelleomkjærlighetsomnoeavgjørendeEntendetertilenpartneretfamiliemedlemenvennelleretkjæledyrMangeharopplevdåblisveketogselvåsvikteMenutrolignokblirikkekjærlighetsevnenødelagtallikevelDenbyggesoppigjengangpågangKjærligheteneretstedåfesteblikketDengirossretningognoeåstyreetterDengirossverdisommenneskerognoeåleveforPåsammemåtesomkjærligheteneretfundamentimenneskeliveterGrunnlovenetfundamentfornasjonenNorgeFor200årsidensamletengruppemennsegpåEidsvollforålagelovensomskullebligrunnlagettildetselvstendigeNorgeGrunnlovensomdengangblevedtattharutvikletsegipaktmedtidenogsikreridagdetnorskefolkrettigheterviletttarforgittihverdagenRettighetersommenneskerimangeandrelandbarekandrømmeomogsomdeslossformedlivetsominnsatsJeghåperatvigjennomjubileumsfeiringeni2014vilbliminnetomhvaGrunnlovenegentligbetyrforosssåvikanfortsetteåarbeideforverdienevårebådeherhjemmeoginternasjonaltJegharlysttilånevnenoeneksemplerpåhvordanGrunnlovenvirkerinnpåenkeltmenneskerslivTenkdegatduskriveretkritiskinnleggomlandetsstyrepåsosialemedier";
        }
    }
}
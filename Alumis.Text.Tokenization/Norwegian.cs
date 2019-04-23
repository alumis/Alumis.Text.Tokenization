using System;
using System.Collections.Generic;
using System.Text;

namespace Alumis.Text.Tokenization
{
    static class Norwegian
    {
        public static Dictionary<string, (bool IsTerminal, bool IsPartial)> TokenizerExceptionsIndex = new Dictionary<string, (bool IsTerminal, bool IsPartial)>();

        static Norwegian()
        {
            var tokenizerExceptions = new string[]
            {
                "adm.dir.", "a.m.", "Aq.", "b.c.", "bl.a.", "bla.", "bm.", "bto.", "ca.",
                "cand.mag.", "c.c.", "co.", "d.d.", "dept.", "d.m.", "dr.philos.", "dvs.",
                "d.y.", "E. coli", "eg.", "ekskl.", "e.Kr.", "el.", "e.l.", "et.", "etg.",
                "ev.", "evt.", /*"f.",*/ "f.eks.", "fhv.", "fk.", "f.Kr.", "f.o.m.", "foreg.",
                "fork.", "fv.", "fvt.", /*"g.",*/ "gt.", "gl.", "gno.", "gnr.", "grl.", "hhv.",
                "hoh.", "hr.", "h.r.adv.", "ifb.", "ifm.", "iht.", "inkl.", "istf.", "jf.",
                "jr.", "jun.", "kfr.", "kgl.res.", "kl.", "komm.", "kst.", "lø.", "ma.",
                "mag.art.", "m.a.o.", "md.", "mfl.", "mill.", "min.", "m.m.", "mnd.",
                "moh.", "Mr.", "muh.", "mv.", "mva.", "ndf.", "no.", "nov.", "nr.", "nto.",
                "nyno.", "n.å.", "o.a.", "off.", "ofl.", "okt.", "o.l.", "on.", "op.",
                "osv.", "ovf.", "p.", "p.a.", "Pb.", "pga.", "ph.d.", "pkt.", "p.m.", "pr.",
                "pst.", "p.t.", "red.anm.", "ref.", "res.", "res.kap.", "resp.", "rv.",
                /*"s.",*/ "s.d.", "sen.", "sep.", "siviling.", /*"sms.",*/ "spm.", "sr.", "sst.",
                "st.", "stip.", "stk.", "st.meld.", "st.prp.", "stud.", "s.u.", "sv.",
                "sø.", "s.å.", "såk.", "temp.", "ti.", "tils.", "tilsv.", "tl;dr", "tlf.",
                "to.", "t.o.m.", "ult.", "utg.", "v.", "vedk.", "vedr.", "vg.", "vgs.",
                "vha.", "vit.ass.", "vn.", "vol.", "vs.", "vsa.", "årg.", "årh."
            };

            (bool IsTerminal, bool IsPartial) entry;

            foreach (var s in tokenizerExceptions)
            {
                for (var i = 0; i < s.Length - 1;)
                {
                    var str = s.Substring(0, ++i);

                    if (TokenizerExceptionsIndex.TryGetValue(str, out entry))
                        TokenizerExceptionsIndex[str] = (entry.IsTerminal, true);

                    else TokenizerExceptionsIndex[str] = (false, true);
                }

                if (TokenizerExceptionsIndex.TryGetValue(s, out entry))
                    TokenizerExceptionsIndex[s] = (true, true);

                else TokenizerExceptionsIndex[s] = (true, false);
            }
        }
    }
}

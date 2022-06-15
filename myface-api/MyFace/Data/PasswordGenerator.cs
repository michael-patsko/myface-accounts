using System;
using System.Collections.Generic;

namespace MyFace.Data
{
    public static class PasswordGenerator
    {
        private static readonly List<string> Data = new List<string>()
        {
            "p269+UAgrF",
            "Xg2kzD,7wB",
            "Jw!ur*3S9a",
            "zY8pe5C?ys",
            "BA8VyP9-v2",
            "GRDzk.F4Qb",
            "Nnz8TC7J+Q",
            "m-c3rAjyCR",
            "E.Jy6Qjtq-",
            "fT,43qW?an",
            "PK.26mrpxd",
            "XL-x2C!WsD",
            "b7m*C_jJe8",
            "Sqk5HKt?-v",
            "T.qYL3jJ6W",
            "P,MFgr8pXu",
            "xLB!dv3q7W",
            "rh26B-49Wc",
            "B5bf+-TjLE",
            "sMj4m?N8eg",
            "Zn,KTfYR37",
            "XK9-W*kG7E",
            "FutYe65?Q,",
            "w38+*7!-Nz",
            "hfrR4_?J9!",
            "DyX!M7tN3d",
            "k!v_TVm587",
            "b96u_5T2ka",
            "qe7p62-Dgv",
            "x39!En-eBW",
            "XvY8,qkK6-",
            "eC,!4zS3h5",
            "nFLN4p*e6q",
            "zN9r*Uh_84",
            "MJ2!s.*pz_",
            "bp5E6f+-d4",
            "f!V5A4Ts-h",
            "UjrEZ+C7ae",
            "s!D_9g5C*6",
            "W3EhaeA-KV",
            "SF.VNA93gq",
            "PEK3Lw+WMu",
            "L!wMPA3s_H",
            "k2X6.R?7eG",
            "Mf6cJ8We+A",
            "D+xV38sZB?",
            "q!6Tma?cEL",
            "F2-fDadJ?g",
            "S5HZd.8t7+",
            "c!6vPrdREn",
            "d48C.jTcGa",
            "Z46*wz+LP2",
            "A4Cswf+V7b",
            "zhQp3.s2xD",
            "X2*z9fxAJQ",
            "kUc.Xmp7KR",
            "Sd4Zt_vA+q",
            "j?62Us75vm",
            "a_tTkvQ4cJ",
            "sQvG25?XpL",
            "bEh!7*LNvQ",
            "dUR?7xwamE",
            "Q3S5?Wu8Py",
            "SE2Bc,H85b",
            "Vv?xXLQ5+R",
            "JL8-baAnH7",
            "kuj2qpRP_A",
            "Sb?5s3AEh2",
            "L4E6T-8a?Z",
            "SyF2xv+_em",
            "YT,j4LtrDH",
            "BcR*H,3eJu",
            "CHe,7vRh!P",
            "Mv*3GmA57Z",
            "sdZ-4x*SwP",
            "thBW5mF!7d",
            "bAGJ_cs73S",
            "j2WB,.f6m!",
            "Qz?7eP,R+G",
            "x+2H?Ks6F.",
            "Tp8D_Jv!*V",
            "YFcEs_+.4L",
            "HNFS-2sazB",
            "N,9V28cbZU",
            "wJz2F.-+4S",
            "At7p,F2QZD",
            "sda2wH,7_e",
            "Nxw-+k4SMu",
            "b.5cHk2f!g",
            "z.GY,Cs493",
            "L-5yX,C4a.",
            "VewcB.E3-,",
            "mx+HB2Pwk9",
            "hSWsH7-Agt",
            "j6BUS+H_z-",
            "VEHW86h!fY",
            "M2H.!74hG+",
            "a*xvzWL286",
            "kx*h?FpJ8Y",
            "Z8_pShPDMG",
        };

        private static string CreateRandomPassword()
        {
            Random random = new Random();
            int index = random.Next(0, Data.Count - 1);

            return Data[index];
        }

        private static string CreatePasswordFrom(int index)
        {
            return Data[index];
        }
    }
}

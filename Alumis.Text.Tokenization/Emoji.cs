using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Alumis.Text.Tokenization
{
    static class Emoji
    {
        public static Dictionary<string, uint> EmoticonToEmoji = new Dictionary<string, uint>();
        public static Dictionary<string, (uint CodePoint, bool IsPartial)> EmoticonToEmojiIndex = new Dictionary<string, (uint CodePoint, bool IsPartial)>();

        public static HashSet<int> Emojis = new HashSet<int>();

        static Emoji()
        {
            Emojis.Add(0x1f642);
            Emojis.Add(0x1f602);
            Emojis.Add(0x2764);
            Emojis.Add(0x2665);
            Emojis.Add(0x1f60d);
            Emojis.Add(0x1f62d);
            Emojis.Add(0x1f618);
            Emojis.Add(0x1f60a);
            Emojis.Add(0x1f44c);
            Emojis.Add(0x1f495);
            Emojis.Add(0x1f44f);
            Emojis.Add(0x1f601);
            Emojis.Add(0x263a);
            Emojis.Add(0x2661);
            Emojis.Add(0x1f44d);
            Emojis.Add(0x1f629);
            Emojis.Add(0x1f64f);
            Emojis.Add(0x270c);
            Emojis.Add(0x1f60f);
            Emojis.Add(0x1f609);
            Emojis.Add(0x1f64c);
            Emojis.Add(0x1f648);
            Emojis.Add(0x1f4aa);
            Emojis.Add(0x1f604);
            Emojis.Add(0x1f612);
            Emojis.Add(0x1f483);
            Emojis.Add(0x1f496);
            Emojis.Add(0x1f603);
            Emojis.Add(0x1f614);
            Emojis.Add(0x1f631);
            Emojis.Add(0x1f389);
            Emojis.Add(0x1f61c);
            Emojis.Add(0x262f);
            Emojis.Add(0x1f338);
            Emojis.Add(0x1f49c);
            Emojis.Add(0x1f499);
            Emojis.Add(0x2728);
            Emojis.Add(0x1f633);
            Emojis.Add(0x1f497);
            Emojis.Add(0x2605);
            Emojis.Add(0x2588);
            Emojis.Add(0x2600);
            Emojis.Add(0x1f621);
            Emojis.Add(0x1f60e);
            Emojis.Add(0x1f622);
            Emojis.Add(0x1f48b);
            Emojis.Add(0x1f60b);
            Emojis.Add(0x1f64a);
            Emojis.Add(0x1f634);
            Emojis.Add(0x1f3b6);
            Emojis.Add(0x1f49e);
            Emojis.Add(0x1f60c);
            Emojis.Add(0x1f525);
            Emojis.Add(0x1f4af);
            Emojis.Add(0x1f52b);
            Emojis.Add(0x1f49b);
            Emojis.Add(0x1f481);
            Emojis.Add(0x1f49a);
            Emojis.Add(0x266b);
            Emojis.Add(0x1f61e);
            Emojis.Add(0x1f606);
            Emojis.Add(0x1f61d);
            Emojis.Add(0x1f62a);
            Emojis.Add(0xfffd);
            Emojis.Add(0x1f62b);
            Emojis.Add(0x1f605);
            Emojis.Add(0x1f44a);
            Emojis.Add(0x1f480);
            Emojis.Add(0x1f600);
            Emojis.Add(0x1f61a);
            Emojis.Add(0x1f63b);
            Emojis.Add(0xa9);
            Emojis.Add(0x1f440);
            Emojis.Add(0x1f498);
            Emojis.Add(0x1f413);
            Emojis.Add(0x2615);
            Emojis.Add(0x1f44b);
            Emojis.Add(0x270b);
            Emojis.Add(0x1f38a);
            Emojis.Add(0x1f355);
            Emojis.Add(0x2744);
            Emojis.Add(0x1f625);
            Emojis.Add(0x1f615);
            Emojis.Add(0x1f4a5);
            Emojis.Add(0x1f494);
            Emojis.Add(0x1f624);
            Emojis.Add(0x1f608);
            Emojis.Add(0x25ba);
            Emojis.Add(0x2708);
            Emojis.Add(0x1f51d);
            Emojis.Add(0x1f630);
            Emojis.Add(0x26bd);
            Emojis.Add(0x1f611);
            Emojis.Add(0x1f451);
            Emojis.Add(0x1f639);
            Emojis.Add(0x1f449);
            Emojis.Add(0x1f343);
            Emojis.Add(0x1f381);
            Emojis.Add(0x1f620);
            Emojis.Add(0x1f427);
            Emojis.Add(0x2606);
            Emojis.Add(0x1f340);
            Emojis.Add(0x1f388);
            Emojis.Add(0x1f385);
            Emojis.Add(0x1f613);
            Emojis.Add(0x1f623);
            Emojis.Add(0x1f610);
            Emojis.Add(0x270a);
            Emojis.Add(0x1f628);
            Emojis.Add(0x1f616);
            Emojis.Add(0x1f4a4);
            Emojis.Add(0x1f493);
            Emojis.Add(0x1f44e);
            Emojis.Add(0x1f4a6);
            Emojis.Add(0x2714);
            Emojis.Add(0x1f637);
            Emojis.Add(0x26a1);
            Emojis.Add(0x1f64b);
            Emojis.Add(0x1f384);
            Emojis.Add(0x1f4a9);
            Emojis.Add(0x1f3b5);
            Emojis.Add(0x27a1);
            Emojis.Add(0x1f61b);
            Emojis.Add(0x1f62c);
            Emojis.Add(0x1f46f);
            Emojis.Add(0x1f48e);
            Emojis.Add(0x1f33f);
            Emojis.Add(0x1f382);
            Emojis.Add(0x1f31f);
            Emojis.Add(0x1f52e);
            Emojis.Add(0x2757);
            Emojis.Add(0x1f46b);
            Emojis.Add(0x1f3c6);
            Emojis.Add(0x2716);
            Emojis.Add(0x261d);
            Emojis.Add(0x1f619);
            Emojis.Add(0x26c4);
            Emojis.Add(0x1f445);
            Emojis.Add(0x266a);
            Emojis.Add(0x1f342);
            Emojis.Add(0x1f48f);
            Emojis.Add(0x1f52a);
            Emojis.Add(0x1f334);
            Emojis.Add(0x1f448);
            Emojis.Add(0x1f339);
            Emojis.Add(0x1f646);
            Emojis.Add(0x279c);
            Emojis.Add(0x1f47b);
            Emojis.Add(0x1f4b0);
            Emojis.Add(0x1f37b);
            Emojis.Add(0x1f645);
            Emojis.Add(0x1f31e);
            Emojis.Add(0x1f341);
            Emojis.Add(0x2b50);
            Emojis.Add(0x25aa);
            Emojis.Add(0x1f380);
            Emojis.Add(0x2501);
            Emojis.Add(0x2637);
            Emojis.Add(0x1f437);
            Emojis.Add(0x1f649);
            Emojis.Add(0x1f33a);
            Emojis.Add(0x1f485);
            Emojis.Add(0x1f436);
            Emojis.Add(0x1f31a);
            Emojis.Add(0x1f47d);
            Emojis.Add(0x1f3a4);
            Emojis.Add(0x1f46d);
            Emojis.Add(0x1f3a7);
            Emojis.Add(0x1f446);
            Emojis.Add(0x1f378);
            Emojis.Add(0x1f377);
            Emojis.Add(0xae);
            Emojis.Add(0x1f349);
            Emojis.Add(0x1f607);
            Emojis.Add(0x2611);
            Emojis.Add(0x1f3c3);
            Emojis.Add(0x1f63f);
            Emojis.Add(0x2502);
            Emojis.Add(0x1f4a3);
            Emojis.Add(0x1f37a);
            Emojis.Add(0x25b6);
            Emojis.Add(0x1f632);
            Emojis.Add(0x1f3b8);
            Emojis.Add(0x1f379);
            Emojis.Add(0x1f4ab);
            Emojis.Add(0x1f4da);
            Emojis.Add(0x1f636);
            Emojis.Add(0x1f337);
            Emojis.Add(0x1f49d);
            Emojis.Add(0x1f4a8);
            Emojis.Add(0x1f3c8);
            Emojis.Add(0x1f48d);
            Emojis.Add(0x2614);
            Emojis.Add(0x1f478);
            Emojis.Add(0x1f1ea);
            Emojis.Add(0x2591);
            Emojis.Add(0x1f369);
            Emojis.Add(0x1f47e);
            Emojis.Add(0x2601);
            Emojis.Add(0x1f33b);
            Emojis.Add(0x1f635);
            Emojis.Add(0x1f4d2);
            Emojis.Add(0x21bf);
            Emojis.Add(0x1f42f);
            Emojis.Add(0x1f47c);
            Emojis.Add(0x1f354);
            Emojis.Add(0x1f638);
            Emojis.Add(0x1f476);
            Emojis.Add(0x21be);
            Emojis.Add(0x1f490);
            Emojis.Add(0x1f30a);
            Emojis.Add(0x1f366);
            Emojis.Add(0x1f353);
            Emojis.Add(0x1f447);
            Emojis.Add(0x1f486);
            Emojis.Add(0x1f374);
            Emojis.Add(0x1f627);
            Emojis.Add(0x1f1f8);
            Emojis.Add(0x1f62e);
            Emojis.Add(0x2593);
            Emojis.Add(0x1f6ab);
            Emojis.Add(0x1f63d);
            Emojis.Add(0x1f308);
            Emojis.Add(0x1f640);
            Emojis.Add(0x26a0);
            Emojis.Add(0x1f3ae);
            Emojis.Add(0x256f);
            Emojis.Add(0x1f346);
            Emojis.Add(0x1f370);
            Emojis.Add(0x2713);
            Emojis.Add(0x1f450);
            Emojis.Add(0x1f647);
            Emojis.Add(0x1f35f);
            Emojis.Add(0x1f34c);
            Emojis.Add(0x1f491);
            Emojis.Add(0x1f46c);
            Emojis.Add(0x1f423);
            Emojis.Add(0x1f383);
            Emojis.Add(0x25ac);
            Emojis.Add(0xfffc);
            Emojis.Add(0x1f61f);
            Emojis.Add(0x1f43e);
            Emojis.Add(0x1f393);
            Emojis.Add(0x1f3ca);
            Emojis.Add(0x1f36b);
            Emojis.Add(0x1f4f7);
            Emojis.Add(0x1f444);
            Emojis.Add(0x1f33c);
            Emojis.Add(0x1f6b6);
            Emojis.Add(0x1f431);
            Emojis.Add(0x2551);
            Emojis.Add(0x1f438);
            Emojis.Add(0x1f1fa);
            Emojis.Add(0x1f47f);
            Emojis.Add(0x1f6ac);
            Emojis.Add(0x273f);
            Emojis.Add(0x1f4d6);
            Emojis.Add(0x1f412);
            Emojis.Add(0x1f30d);
            Emojis.Add(0x250a);
            Emojis.Add(0x1f425);
            Emojis.Add(0x1f300);
            Emojis.Add(0x1f43c);
            Emojis.Add(0x1f3a5);
            Emojis.Add(0x1f484);
            Emojis.Add(0x1f4b8);
            Emojis.Add(0x26d4);
            Emojis.Add(0x25cf);
            Emojis.Add(0x1f3c0);
            Emojis.Add(0x1f489);
            Emojis.Add(0x1f49f);
            Emojis.Add(0x1f697);
            Emojis.Add(0x1f62f);
            Emojis.Add(0x1f4dd);
            Emojis.Add(0x2550);
            Emojis.Add(0x2666);
            Emojis.Add(0x1f4ad);
            Emojis.Add(0x1f319);
            Emojis.Add(0x1f41f);
            Emojis.Add(0x1f463);
            Emojis.Add(0x261e);
            Emojis.Add(0x2702);
            Emojis.Add(0x1f5ff);
            Emojis.Add(0x1f35d);
            Emojis.Add(0x1f46a);
            Emojis.Add(0x1f36d);
            Emojis.Add(0x1f303);
            Emojis.Add(0x274c);
            Emojis.Add(0x1f430);
            Emojis.Add(0x1f48a);
            Emojis.Add(0x1f6a8);
            Emojis.Add(0x1f626);
            Emojis.Add(0x1f36a);
            Emojis.Add(0x1f363);
            Emojis.Add(0x256d);
            Emojis.Add(0x2727);
            Emojis.Add(0x1f386);
            Emojis.Add(0x256e);
            Emojis.Add(0x1f38e);
            Emojis.Add(0x1f1e9);
            Emojis.Add(0x2705);
            Emojis.Add(0x1f479);
            Emojis.Add(0x1f4f1);
            Emojis.Add(0x1f64d);
            Emojis.Add(0x1f351);
            Emojis.Add(0x1f3bc);
            Emojis.Add(0x1f50a);
            Emojis.Add(0x1f30c);
            Emojis.Add(0x1f34e);
            Emojis.Add(0x1f43b);
            Emojis.Add(0x2500);
            Emojis.Add(0x2570);
            Emojis.Add(0x1f487);
            Emojis.Add(0x266c);
            Emojis.Add(0x265a);
            Emojis.Add(0x1f534);
            Emojis.Add(0x1f371);;
            Emojis.Add(0x1f34a);
            Emojis.Add(0x1f352);
            Emojis.Add(0x1f42d);
            Emojis.Add(0x1f45f);
            Emojis.Add(0x1f30e);
            Emojis.Add(0x1f34d);
            Emojis.Add(0x1f42e);
            Emojis.Add(0x1f4f2);
            Emojis.Add(0x263c);
            Emojis.Add(0x1f305);
            Emojis.Add(0x1f1f7);
            Emojis.Add(0x1f460);
            Emojis.Add(0x1f33d);
            Emojis.Add(0x1f4a7);;
            Emojis.Add(0x2753);
            Emojis.Add(0x1f36c);
            Emojis.Add(0x1f63a);
            Emojis.Add(0x1f434);
            Emojis.Add(0x1f680);
            Emojis.Add(0xa6);
            Emojis.Add(0x1f4a2);
            Emojis.Add(0x1f3ac);
            Emojis.Add(0x1f367);
            Emojis.Add(0x1f35c);
            Emojis.Add(0x1f40f);
            Emojis.Add(0x1f418);
            Emojis.Add(0x1f467);
            Emojis.Add(0x2800);
            Emojis.Add(0x1f3c4);
            Emojis.Add(0x27a4);
            Emojis.Add(0x2b06);
            Emojis.Add(0x1f34b);
            Emojis.Add(0x1f197);
            Emojis.Add(0x26aa);
            Emojis.Add(0x1f4fa);
            Emojis.Add(0x1f345);
            Emojis.Add(0x26c5);
            Emojis.Add(0x1f422);
            Emojis.Add(0x1f459);
            Emojis.Add(0x1f3e1);
            Emojis.Add(0x1f33e);
            Emojis.Add(0x25c9);
            Emojis.Add(0x270f);
            Emojis.Add(0x1f42c);
            Emojis.Add(0x1f364);
            Emojis.Add(0x1f1f9);
            Emojis.Add(0x2663);
            Emojis.Add(0x1f41d);
            Emojis.Add(0x1f31d);
            Emojis.Add(0x1f1ee);
            Emojis.Add(0x1f50b);;
            Emojis.Add(0x1f40d);
            Emojis.Add(0x2654);
            Emojis.Add(0x1f373);
            Emojis.Add(0x1f535);
            Emojis.Add(0x1f63e);;
            Emojis.Add(0x1f315);
            Emojis.Add(0x1f428);
            Emojis.Add(0x1f510);
            Emojis.Add(0x1f4bf);
            Emojis.Add(0x2741);
            Emojis.Add(0x1f333);
            Emojis.Add(0x1f470);
            Emojis.Add(0x2740);
            Emojis.Add(0x2693);
            Emojis.Add(0x1f6b4);
            Emojis.Add(0x2580);
            Emojis.Add(0x1f457);
            Emojis.Add(0x2795);
            Emojis.Add(0x1f4ac);
            Emojis.Add(0x2592);
            Emojis.Add(0x1f51c);
            Emojis.Add(0x1f368);
            Emojis.Add(0x1f4b2);
            Emojis.Add(0x26fd);
            Emojis.Add(0x1f359);
            Emojis.Add(0x1f357);
            Emojis.Add(0x1f372);
            Emojis.Add(0x1f365);;
            Emojis.Add(0x25b8);
            Emojis.Add(0x265b);
            Emojis.Add(0x1f63c);
            Emojis.Add(0x1f419);
            Emojis.Add(0x1f468);
            Emojis.Add(0x1f35a);
            Emojis.Add(0x1f356);
            Emojis.Add(0x2668);
            Emojis.Add(0x1f3b9);
            Emojis.Add(0x2655);
            Emojis.Add(0x2583);
            Emojis.Add(0x1f698);
            Emojis.Add(0x1f34f);
            Emojis.Add(0x1f469);
            Emojis.Add(0x1f466);
            Emojis.Add(0x1f1ec);
            Emojis.Add(0x1f1e7);
            Emojis.Add(0x2620);
            Emojis.Add(0x1f420);
            Emojis.Add(0x1f6b9);
            Emojis.Add(0x1f4b5);
            Emojis.Add(0x2730);
            Emojis.Add(0x2560);
            Emojis.Add(0x1f45b);
            Emojis.Add(0x1f699);
            Emojis.Add(0x1f331);
            Emojis.Add(0x1f4bb);
            Emojis.Add(0x1f30f);
            Emojis.Add(0x2584);
            Emojis.Add(0x1f453);
            Emojis.Add(0x25c4);
            Emojis.Add(0x26be);
            Emojis.Add(0x1f332);
            Emojis.Add(0x1f474);
            Emojis.Add(0x1f3e0);
            Emojis.Add(0x1f347);
            Emojis.Add(0x1f358);
            Emojis.Add(0x1f35b);
            Emojis.Add(0x1f407);
            Emojis.Add(0x1f51e);;
            Emojis.Add(0x1f475);
            Emojis.Add(0x25c0);
            Emojis.Add(0x1f519);
            Emojis.Add(0x1f335);
            Emojis.Add(0x1f43d);
            Emojis.Add(0x1f36e);;
            Emojis.Add(0x1f387);
            Emojis.Add(0x1f40e);
            Emojis.Add(0x2794);
            Emojis.Add(0x1f4b6);
            Emojis.Add(0x1f424);
            Emojis.Add(0x2569);
            Emojis.Add(0x1f6c0);
            Emojis.Add(0x1f311);
            Emojis.Add(0x1f6b2);
            Emojis.Add(0x1f411);;
            Emojis.Add(0x1f3c1);
            Emojis.Add(0x1f35e);
            Emojis.Add(0x1f3be);
            Emojis.Add(0x255a);
            Emojis.Add(0x1f239);
            Emojis.Add(0x1f433);
            Emojis.Add(0x1f46e);;
            Emojis.Add(0x2639);
            Emojis.Add(0x1f435);
            Emojis.Add(0x272a);
            Emojis.Add(0x25d5);
            Emojis.Add(0x1f5fc);
            Emojis.Add(0x2590);
            Emojis.Add(0x2660);
            Emojis.Add(0x2533);
            Emojis.Add(0x1f47a);;
            Emojis.Add(0x1f41a);
            Emojis.Add(0x1f442);;
            Emojis.Add(0x1f5fd);
            Emojis.Add(0x1f375);
            Emojis.Add(0x1f192);
            Emojis.Add(0x1f36f);
            Emojis.Add(0x1f43a);
            Emojis.Add(0x21e8);
            Emojis.Add(0x27a8);
            Emojis.Add(0x1f313);
            Emojis.Add(0x1f512);
            Emojis.Add(0x256c);
            Emojis.Add(0x1f473);
            Emojis.Add(0x1f302);
            Emojis.Add(0x1f68c);
            Emojis.Add(0x2669);
            Emojis.Add(0x1f361);;
            Emojis.Add(0x2765);
            Emojis.Add(0x1f3a1);
            Emojis.Add(0x1f48c);
            Emojis.Add(0x1f429);
            Emojis.Add(0x1f31c);
            Emojis.Add(0x231a);
            Emojis.Add(0x1f6bf);
            Emojis.Add(0x1f416);
            Emojis.Add(0x1f506);
            Emojis.Add(0x1f31b);
            Emojis.Add(0x1f482);;
            Emojis.Add(0x1f414);
            Emojis.Add(0x1f64e);;
            Emojis.Add(0x1f3e9);
            Emojis.Add(0x1f1eb);
            Emojis.Add(0x1f528);;
            Emojis.Add(0x1f4e2);
            Emojis.Add(0x1f426);
            Emojis.Add(0x1f432);;
            Emojis.Add(0x267b);
            Emojis.Add(0x1f318);
            Emojis.Add(0x1f350);
            Emojis.Add(0x1f314);
            Emojis.Add(0x2565);
            Emojis.Add(0x274a);
            Emojis.Add(0x1f456);
            Emojis.Add(0x1f6ba);
            Emojis.Add(0x1f617);
            Emojis.Add(0x1f3ad);
            Emojis.Add(0x1f404);
            Emojis.Add(0x25df);
            Emojis.Add(0x1f362);;
            Emojis.Add(0x1f3a8);
            Emojis.Add(0x2b07);
            Emojis.Add(0x1f6bc);
            Emojis.Add(0x26f2);
            Emojis.Add(0x2581);
            Emojis.Add(0x1f1f4);
            Emojis.Add(0x1f317);
            Emojis.Add(0x1f316);
            Emojis.Add(0x1f505);
            Emojis.Add(0x1f45c);
            Emojis.Add(0x1f40c);
            Emojis.Add(0x1f4bc);
            Emojis.Add(0x1f695);
            Emojis.Add(0x1f439);
            Emojis.Add(0x1f320);
            Emojis.Add(0x1f408);
            Emojis.Add(0x21e7);
            Emojis.Add(0x260e);
            Emojis.Add(0x1f301);
            Emojis.Add(0x26ab);
            Emojis.Add(0x2667);
            Emojis.Add(0x1f3f0);
            Emojis.Add(0x1f6b5);
            Emojis.Add(0x1f3a2);
            Emojis.Add(0x1f3b7);
            Emojis.Add(0x1f390);
            Emojis.Add(0x2508);
            Emojis.Add(0x2557);
            Emojis.Add(0x2571);
            Emojis.Add(0x1f307);
            Emojis.Add(0x23f0);
            Emojis.Add(0x21e9);
            Emojis.Add(0x1f682);
            Emojis.Add(0x25e0);
            Emojis.Add(0x1f3bf);
            Emojis.Add(0x2726);
            Emojis.Add(0x1f194);
            Emojis.Add(0x26ea);
            Emojis.Add(0x1f312);
            Emojis.Add(0x1f42a);
            Emojis.Add(0x2554);
            Emojis.Add(0x255d);
            Emojis.Add(0x1f454);
            Emojis.Add(0x1f531);
            Emojis.Add(0x1f193);
            Emojis.Add(0x1f40b);
            Emojis.Add(0x25bd);
            Emojis.Add(0x2582);
            Emojis.Add(0x1f41b);
            Emojis.Add(0x1f455);
            Emojis.Add(0x1f68b);
            Emojis.Add(0x1f4b3);
            Emojis.Add(0x1f306);
            Emojis.Add(0x1f3e7);
            Emojis.Add(0x1f4a1);
            Emojis.Add(0x1f539);
            Emojis.Add(0x2b05);
            Emojis.Add(0x1f360);
            Emojis.Add(0x1f42b);
            Emojis.Add(0x1f3ea);
            Emojis.Add(0x6e9);
            Emojis.Add(0x1f1f1);
            Emojis.Add(0x1f4f9);
            Emojis.Add(0x1f45e);
            Emojis.Add(0x1f691);
            Emojis.Add(0x1f198);
            Emojis.Add(0x1f45a);
            Emojis.Add(0x1f68d);
            Emojis.Add(0x25a1);
            Emojis.Add(0x1f402);
            Emojis.Add(0x1f6a3);
            Emojis.Add(0x2733);
            Emojis.Add(0x1f3c9);
            Emojis.Add(0x1f5fb);
            Emojis.Add(0x1f400);
            Emojis.Add(0x2566);
            Emojis.Add(0x26fa);
            Emojis.Add(0x1f415);
            Emojis.Add(0x1f3c2);
            Emojis.Add(0x1f461);
            Emojis.Add(0x1f4fb);
            Emojis.Add(0x2712);
            Emojis.Add(0x1f330);
            Emojis.Add(0x1f3e2);
            Emojis.Add(0x1f392);
            Emojis.Add(0x2312);
            Emojis.Add(0x1f3eb);
            Emojis.Add(0x1f4f4);
            Emojis.Add(0x1f6a2);
            Emojis.Add(0x1f69a);
            Emojis.Add(0x1f409);
            Emojis.Add(0x2752);
            Emojis.Add(0x1f40a);
            Emojis.Add(0x1f514);
            Emojis.Add(0x25e2);
            Emojis.Add(0x1f3e5);
            Emojis.Add(0x2754);
            Emojis.Add(0x1f696);
            Emojis.Add(0x1f0cf);
            Emojis.Add(0x25bc);
            Emojis.Add(0x258c);
            Emojis.Add(0x261b);
            Emojis.Add(0x2729);
            Emojis.Add(0x1f492);
            Emojis.Add(0x1f6a4);
            Emojis.Add(0x1f410);
            Emojis.Add(0x25a0);
            Emojis.Add(0x1f51a);
            Emojis.Add(0x1f3bb);
            Emojis.Add(0x1f537);
            Emojis.Add(0x1f6a6);
            Emojis.Add(0x1f513);
            Emojis.Add(0x1f3bd);
            Emojis.Add(0x1f4c5);
            Emojis.Add(0x1f3ba);
            Emojis.Add(0x272f);
            Emojis.Add(0x1f348);
            Emojis.Add(0x2709);
            Emojis.Add(0x2563);
            Emojis.Add(0x25e4);
            Emojis.Add(0x25cb);
            Emojis.Add(0x1f37c);
            Emojis.Add(0x1f4c0);
            Emojis.Add(0x1f69b);
            Emojis.Add(0x1f4d3);
            Emojis.Add(0x2609);
            Emojis.Add(0x1f4b4);
            Emojis.Add(0x253c);
            Emojis.Add(0x1f403);
            Emojis.Add(0x27b0);
            Emojis.Add(0x1f50c);
            Emojis.Add(0x1f344);
            Emojis.Add(0x1f4d5);
            Emojis.Add(0x1f4e3);
            Emojis.Add(0x1f693);
            Emojis.Add(0x1f417);
            Emojis.Add(0x21aa);
            Emojis.Add(0x26f3);
            Emojis.Add(0x253b);
            Emojis.Add(0x251b);
            Emojis.Add(0x2503);
            Emojis.Add(0x1f471);
            Emojis.Add(0x23f3);
            Emojis.Add(0x1f4ba);
            Emojis.Add(0x1f3c7);
            Emojis.Add(0x263b);
            Emojis.Add(0x1f4de);
            Emojis.Add(0x24b6);
            Emojis.Add(0x1f309);
            Emojis.Add(0x1f6a9);
            Emojis.Add(0x270e);
            Emojis.Add(0x1f4c3);
            Emojis.Add(0x1f3e8);
            Emojis.Add(0x1f4cc);
            Emojis.Add(0x264e);
            Emojis.Add(0x1f4b7);
            Emojis.Add(0x1f684);
            Emojis.Add(0x25b2);
            Emojis.Add(0x26f5);
            Emojis.Add(0x1f538);
            Emojis.Add(0x231b);
            Emojis.Add(0x1f69c);
            Emojis.Add(0x1f406);
            Emojis.Add(0x1f452);
            Emojis.Add(0x2755);
            Emojis.Add(0x1f51b);
            Emojis.Add(0x2662);
            Emojis.Add(0x1f1f2);
            Emojis.Add(0x2745);
            Emojis.Add(0x1f45d);
            Emojis.Add(0x271e);
            Emojis.Add(0x25e1);
            Emojis.Add(0x1f38b);
            Emojis.Add(0x1f465);
            Emojis.Add(0x1f4f5);
            Emojis.Add(0x1f421);
            Emojis.Add(0x25c6);
            Emojis.Add(0x1f3ef);
            Emojis.Add(0x2602);
            Emojis.Add(0x1f52d);
            Emojis.Add(0x1f3aa);
            Emojis.Add(0x1f41c);
            Emojis.Add(0x264c);
            Emojis.Add(0x2610);
            Emojis.Add(0x1f477);
            Emojis.Add(0x21b3);
            Emojis.Add(0x1f508);
            Emojis.Add(0x1f4c4);
            Emojis.Add(0x1f4cd);
            Emojis.Add(0x1f690);
            Emojis.Add(0x1f694);
            Emojis.Add(0x1f30b);
            Emojis.Add(0x1f4e1);
            Emojis.Add(0x23e9);
            Emojis.Add(0x1f6b3);
            Emojis.Add(0x2718);
            Emojis.Add(0x6de);
            Emojis.Add(0x263e);
            Emojis.Add(0x1f170);
            Emojis.Add(0x1f4e5);
            Emojis.Add(0x1f1fc);
            Emojis.Add(0x2513);
            Emojis.Add(0x2523);
            Emojis.Add(0x24c1);
            Emojis.Add(0x24ba);
            Emojis.Add(0x1f526);
            Emojis.Add(0x1f464);
            Emojis.Add(0x1f681);
            Emojis.Add(0x1f3a0);
            Emojis.Add(0x1f401);
            Emojis.Add(0x1f4d7);
            Emojis.Add(0x2510);
            Emojis.Add(0x262e);
            Emojis.Add(0x2642);
            Emojis.Add(0x25de);
            Emojis.Add(0x1f4ef);
            Emojis.Add(0x1f529);
            Emojis.Add(0x1f462);
            Emojis.Add(0x25c2);
            Emojis.Add(0x1f4f0);
            Emojis.Add(0x1f4f6);
            Emojis.Add(0x1f6a5);
            Emojis.Add(0x1f304);
            Emojis.Add(0x1f5fe);
            Emojis.Add(0x1f536);
            Emojis.Add(0x1f3e4);
            Emojis.Add(0x1f3a9);
            Emojis.Add(0x24c2);
            Emojis.Add(0x1f527);
            Emojis.Add(0x1f405);
            Emojis.Add(0x266e);
            Emojis.Add(0x1f17e);
            Emojis.Add(0x1f504);
            Emojis.Add(0x2604);
            Emojis.Add(0x2628);

            // https://raw.githubusercontent.com/banyan/emoji-emoticon-to-unicode/master/emoji-emoticon-to-unicode.js

            EmoticonToEmoji["<3"] = 0x2764;

            EmoticonToEmoji["</3"] = 0x1f494;

            EmoticonToEmoji[":')"] = 0x1f642;

            EmoticonToEmoji[":'-)"] = 0x1f642;

            EmoticonToEmoji[":D"] = 0x1f603;

            EmoticonToEmoji[":-D"] = 0x1f603;

            EmoticonToEmoji["=D"] = 0x1f603;

            EmoticonToEmoji[":)"] = 0x1f642;

            EmoticonToEmoji[":-)"] = 0x1f604;

            EmoticonToEmoji["=]"] = 0x1f604;

            EmoticonToEmoji["=)"] = 0x1f604;

            EmoticonToEmoji[":]"] = 0x1f604;

            EmoticonToEmoji["':)"] = 0x1f605;

            EmoticonToEmoji["':-)"] = 0x1f605;

            EmoticonToEmoji["'=)"] = 0x1f605;

            EmoticonToEmoji["':D"] = 0x1f605;

            EmoticonToEmoji["':-D"] = 0x1f605;

            EmoticonToEmoji["'=D"] = 0x1f605;

            EmoticonToEmoji[">:)"] = 0x1f606;

            EmoticonToEmoji[">;)"] = 0x1f606;

            EmoticonToEmoji[">:-)"] = 0x1f606;

            EmoticonToEmoji[">=)"] = 0x1f606;

            EmoticonToEmoji[";)"] = 0x1f609;

            EmoticonToEmoji[";-)"] = 0x1f609;

            EmoticonToEmoji["*-)"] = 0x1f609;

            EmoticonToEmoji["*)"] = 0x1f609;

            EmoticonToEmoji[";-]"] = 0x1f609;

            EmoticonToEmoji[";]"] = 0x1f609;

            EmoticonToEmoji[";D"] = 0x1f609;

            EmoticonToEmoji[";^)"] = 0x1f609;

            EmoticonToEmoji["':("] = 0x1f613;

            EmoticonToEmoji[":(("] = 0x1f620;

            EmoticonToEmoji["':-("] = 0x1f613;

            EmoticonToEmoji["'=("] = 0x1f613;

            EmoticonToEmoji[":*"] = 0x1f618;

            EmoticonToEmoji[":-*"] = 0x1f618;

            EmoticonToEmoji["=*"] = 0x1f618;

            EmoticonToEmoji[":^*"] = 0x1f618;

            EmoticonToEmoji[">:P"] = 0x1f61c;

            EmoticonToEmoji["X-P"] = 0x1f61c;

            EmoticonToEmoji["x-p"] = 0x1f61c;

            EmoticonToEmoji[">:["] = 0x1f61e;

            EmoticonToEmoji[":-("] = 0x1f61e;

            EmoticonToEmoji[":("] = 0x1f61e;

            EmoticonToEmoji[":-["] = 0x1f61e;

            EmoticonToEmoji[":["] = 0x1f61e;

            EmoticonToEmoji["=("] = 0x1f61e;

            EmoticonToEmoji[">:("] = 0x1f620;

            EmoticonToEmoji[">:-("] = 0x1f620;

            EmoticonToEmoji[":@"] = 0x1f620;

            EmoticonToEmoji[":'("] = 0x1f622;

            EmoticonToEmoji[":'-("] = 0x1f622;

            EmoticonToEmoji[";("] = 0x1f622;

            EmoticonToEmoji[";-("] = 0x1f622;

            EmoticonToEmoji[">.<"] = 0x1f623;

            EmoticonToEmoji[":$"] = 0x1f633;

            EmoticonToEmoji["=$"] = 0x1f633;

            EmoticonToEmoji["#-)"] = 0x1f635;

            EmoticonToEmoji["#)"] = 0x1f635;

            EmoticonToEmoji["%-)"] = 0x1f635;

            EmoticonToEmoji["%)"] = 0x1f635;

            EmoticonToEmoji["X)"] = 0x1f635;

            EmoticonToEmoji["X-)"] = 0x1f635;

            EmoticonToEmoji["*\\0/*"] = 0x1f646;

            EmoticonToEmoji["\\0/"] = 0x1f646;

            EmoticonToEmoji["*\\O/*"] = 0x1f646;

            EmoticonToEmoji["\\O/"] = 0x1f646;

            EmoticonToEmoji["O:-)"] = 0x1f607;

            EmoticonToEmoji["0:-3"] = 0x1f607;

            EmoticonToEmoji["0:3"] = 0x1f607;

            EmoticonToEmoji["0:-)"] = 0x1f607;

            EmoticonToEmoji["0:)"] = 0x1f607;

            EmoticonToEmoji["0;^)"] = 0x1f607;

            EmoticonToEmoji["O:)"] = 0x1f607;

            EmoticonToEmoji["O;-)"] = 0x1f607;

            EmoticonToEmoji["O=)"] = 0x1f607;

            EmoticonToEmoji["0;-)"] = 0x1f607;

            EmoticonToEmoji["O:-3"] = 0x1f607;

            EmoticonToEmoji["O:3"] = 0x1f607;

            EmoticonToEmoji["B-)"] = 0x1f60e;

            EmoticonToEmoji["B)"] = 0x1f60e;

            EmoticonToEmoji["8)"] = 0x1f60e;

            EmoticonToEmoji["8-)"] = 0x1f60e;

            EmoticonToEmoji["B-D"] = 0x1f60e;

            EmoticonToEmoji["8-D"] = 0x1f60e;

            EmoticonToEmoji["-_-"] = 0x1f611;

            EmoticonToEmoji["-__-"] = 0x1f611;

            EmoticonToEmoji["-___-"] = 0x1f611;

            EmoticonToEmoji[">:\\"] = 0x1f615;

            EmoticonToEmoji[">:/"] = 0x1f615;

            EmoticonToEmoji[":-/"] = 0x1f615;

            EmoticonToEmoji[":-."] = 0x1f615;

            EmoticonToEmoji[":/"] = 0x1f615;

            EmoticonToEmoji[":-."] = 0x1f615;

            EmoticonToEmoji[":\\"] = 0x1f615;

            EmoticonToEmoji["=/"] = 0x1f615;

            EmoticonToEmoji["=\\"] = 0x1f615;

            EmoticonToEmoji[":L"] = 0x1f615;

            EmoticonToEmoji["=L"] = 0x1f615;

            EmoticonToEmoji[":P"] = 0x1f61b;

            EmoticonToEmoji[":-P"] = 0x1f61b;

            EmoticonToEmoji["=P"] = 0x1f61b;

            EmoticonToEmoji[":-p"] = 0x1f61b;

            EmoticonToEmoji[":p"] = 0x1f61b;

            EmoticonToEmoji["=p"] = 0x1f61b;

            EmoticonToEmoji[":-Þ"] = 0x1f61b;

            EmoticonToEmoji[":Þ"] = 0x1f61b;

            EmoticonToEmoji[":þ"] = 0x1f61b;

            EmoticonToEmoji[":-þ"] = 0x1f61b;

            EmoticonToEmoji[":-b"] = 0x1f61b;

            EmoticonToEmoji[":b"] = 0x1f61b;

            EmoticonToEmoji["d:"] = 0x1f61b;

            EmoticonToEmoji[":-O"] = 0x1f62e;

            EmoticonToEmoji[":O"] = 0x1f62e;

            EmoticonToEmoji[":-o"] = 0x1f62e;

            EmoticonToEmoji[":o"] = 0x1f62e;

            EmoticonToEmoji["O_O"] = 0x1f62e;

            EmoticonToEmoji[">:O"] = 0x1f62e;

            EmoticonToEmoji[":-X"] = 0x1f636;

            EmoticonToEmoji[":X"] = 0x1f636;

            EmoticonToEmoji[":-#"] = 0x1f636;

            EmoticonToEmoji[":#"] = 0x1f636;

            EmoticonToEmoji["=X"] = 0x1f636;

            EmoticonToEmoji["=x"] = 0x1f636;

            EmoticonToEmoji[":x"] = 0x1f636;

            EmoticonToEmoji[":-x"] = 0x1f636;

            EmoticonToEmoji["=#"] = 0x1f636;

            (uint CodePoint, bool IsPartial) entry;

            foreach (var p in EmoticonToEmoji)
            {
                for (var i = 0; i < p.Key.Length - 1;)
                {
                    var str = p.Key.Substring(0, ++i);

                    if (EmoticonToEmojiIndex.TryGetValue(str, out entry))
                        EmoticonToEmojiIndex[str] = (entry.CodePoint, true);
                    
                    else EmoticonToEmojiIndex[str] = (0, true);
                }

                if (EmoticonToEmojiIndex.TryGetValue(p.Key, out entry))
                    EmoticonToEmojiIndex[p.Key] = (p.Value, true);

                else EmoticonToEmojiIndex[p.Key] = (p.Value, false);
            }
        }
    }
}

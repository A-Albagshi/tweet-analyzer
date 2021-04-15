using System;

namespace twitterTokenizer
{
    class Program
    {
        static void Main(string[] args)
        {
            string value = "SvelteKit looks pretty exciting, I bet @3st#o_l33ai4@ @abcde@fg123.456789 @nski @abc ll be all over it Winkin #_ولي_العهدg face with tongue@asd\\#@a-d_   #@ #@#@#asd#23#@@3#0_32@$s#a  ";

            string tweet = @"A very close game on Vertigo with 
                    @dignitas
                     taking the half 8 - 7.
                    @NAFFLY
                     pulling out the stops to keep
                    @TeamLiquidCS
                     competitive!Fire
                    #BLASTPremier | http://Twitch.tv/BLASTPremier
                    ";

            string value2 = "#تهنئه يتقدم #سناب_الخرج_لايف بالتهاني والتبريكات للأستاذ /عبدالرحمن بن محمد بن ذهيبان تعيينه مديراً لعمليات شركة #قوقل بالشرق الأوسط وتركيا وأفريقيا متمنين له دوام التوفي";

            tweetTokenizer(value);
        }

        static void tweetTokenizer(string source)
        {
            //hashtag -> # + loop( letter | digit | underscore )
            // username -> @ + loop( letter | digit | underscore )

            int i = 0;

            string username = "@";
            int usernameCount  = 0;
            string hashtags = "#";
            int tagsCount = 0;

            // For analyze username 

            while (i < source.Length)
            {
                if (source[i] == '@')
                {
                    i++;
                    if (Char.IsLetterOrDigit(source[i]) || source[i] == '_' )
                    {
                        while (i < source.Length && Char.IsLetterOrDigit(source[i]) || source[i] == '_')
                        {

                            if (i < source.Length-1)
                            {
                                username += source[i];
                                i++;
                            } else
                            {
                                username += source[i];
                                break;
                            }
                        }
                            i--;

                        if (username.Length > 0)
                        {
                            usernameCount++;
                        }
                        Console.WriteLine(username);
                        Console.WriteLine(usernameCount);
                    }
                }
                username = "@";
                i++;
            }

            // For analyze Hashtag 
            i = 0;
            while (i < source.Length)
            {
                if (source[i] == '#')
                {
                    i++;
                    if (Char.IsLetterOrDigit(source[i]) || source[i] == '_')
                    {
                        while (i < source.Length && Char.IsLetterOrDigit(source[i]) || source[i] == '_')
                        {
                            if (i < source.Length - 1)
                            {
                                hashtags += source[i];
                                i++;
                            }
                            else
                            {
                                hashtags += source[i];
                                break;
                            }
                        }
                        i--;
                        if (hashtags.Length > 0)
                        {
                            tagsCount++;
                        }
                        Console.WriteLine(hashtags);
                        Console.WriteLine(tagsCount);
                    }
                }
                hashtags = "#";
                i++;
            }


        }

    }
}

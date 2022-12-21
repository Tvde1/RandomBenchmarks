using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Jobs;
using BenchmarkDotNet.Running;

#if DEBUG

var hashSet4 = TuningImplementation.FindStartOfMarkerUsingHashSet(Input.String, 4);
var span4 = TuningImplementation.FindStartOfMarkerUsingSpan(Input.String, 4);
var jump4 = TuningImplementation.FindStartOfMarkerUsingSkipForward(Input.String, 4);
var jumpRev4 = TuningImplementation.FindStartOfMarkerUsingSkipForwardReverse(Input.String, 4);

var are4Equal = hashSet4 == span4 && span4 == jump4 && jump4 == jumpRev4;
Console.WriteLine($"Are all 4 equal: {are4Equal}");

var hashSet14 = TuningImplementation.FindStartOfMarkerUsingHashSet(Input.String, 14);
var span14 = TuningImplementation.FindStartOfMarkerUsingSpan(Input.String, 14);
var jump14 = TuningImplementation.FindStartOfMarkerUsingSkipForward(Input.String, 14);
var jumpRev14 = TuningImplementation.FindStartOfMarkerUsingSkipForwardReverse(Input.String, 14);

var are14Equal = hashSet14 == span14 && span14 == jump14 && jump14 == jumpRev14;
Console.WriteLine($"Are all 14 equal: {are14Equal}");

#endif

BenchmarkRunner.Run<Benchmark>();

[SimpleJob(RuntimeMoniker.Net70)]
[MemoryDiagnoser(false)]
public class Benchmark
{
    [Params(Input.String)]
    public string Message { get; set; } = null!;

    [Params(4, 14)]
    public int MarkerLength { get; set; }

    [Benchmark]
    public int UsingHashLinq() => TuningImplementation.FindStartOfMarkerUsingLinq(Message, MarkerLength);
    
    [Benchmark]
    public int UsingHashSet() => TuningImplementation.FindStartOfMarkerUsingHashSet(Message, MarkerLength);

    [Benchmark(Baseline = true)]
    public int UsingSpan() => TuningImplementation.FindStartOfMarkerUsingSpan(Message, MarkerLength);

    [Benchmark]
    public int UsingJumps() => TuningImplementation.FindStartOfMarkerUsingSkipForward(Message, MarkerLength);
    
    [Benchmark]
    public int UsingJumpsReverse() => TuningImplementation.FindStartOfMarkerUsingSkipForwardReverse(Message, MarkerLength);
}

file static class TuningImplementation
{
    public static int FindStartOfMarkerUsingLinq(string input, int markerLength)
    {
        for (int i = 0; i < input.Length - markerLength; i++)
            if (input.Substring(i, markerLength).Distinct().Count() == markerLength)
                return i;

        throw new InvalidOperationException("The input has no valid marker.");
    }
    
    public static int FindStartOfMarkerUsingHashSet(string input, int markerLength)
    {
        for (int i = 0; i < input.Length - markerLength; i++)
            if (new HashSet<char>(input.Substring(i, markerLength)).Count == markerLength)
                return i;

        throw new InvalidOperationException("The input has no valid marker.");
    }

    public static int FindStartOfMarkerUsingSpan(string input, int markerLength)
    {
        ReadOnlySpan<char> span = input.AsSpan();
        for (int index = 0; index < input.Length - markerLength; index++)
        {
            ReadOnlySpan<char> subSpan = span[index..(index + markerLength)];

            if (!ContainsDuplicates(subSpan))
                return index;
        }

        throw new InvalidOperationException("The input has no valid marker.");

        static bool ContainsDuplicates(ReadOnlySpan<char> input)
        {
            for (int i = 0; i < input.Length; i++)
            for (int j = i + 1; j < input.Length; j++)
                if (input[i] == input[j])
                    return true;

            return false;
        }
    }

    public static int FindStartOfMarkerUsingSkipForward(string input, int payloadSize)
    {
        ReadOnlySpan<char> span = input.AsSpan();
        Span<int> charOccurredAt = stackalloc int['z' - 'a' + 1];

        int markerBase = 0;
        for (int i = 0; i < payloadSize; i++)
        {
            int currCharIndex = markerBase + i;
            char currChar = span[currCharIndex];
            int currCharAlreadyOccuredAt = charOccurredAt[currChar - 'a'];

            charOccurredAt[currChar - 'a'] = currCharIndex;

            if (currCharAlreadyOccuredAt >= markerBase &&
                currCharIndex != currCharAlreadyOccuredAt)
            {
                markerBase = currCharAlreadyOccuredAt + 1;
                i = -1;
            }
        }

        return markerBase;
    }

public static int FindStartOfMarkerUsingSkipForwardReverse(string input, int payloadSize)
{
    ReadOnlySpan<char> span = input.AsSpan();
    Span<int> charOccurredAt = stackalloc int['z' - 'a' + 1];
    charOccurredAt.Fill(-1);

    int markerBase = 0;
    for (int i = payloadSize - 1; i >= 0; i--)
    {
        int currCharIndex = markerBase + i;
        char currChar = span[currCharIndex];
        int currCharAlreadyOccuredAt = charOccurredAt[currChar - 'a'];

        if (currCharAlreadyOccuredAt >= markerBase &&
            currCharIndex < currCharAlreadyOccuredAt)
        {
            markerBase = currCharIndex + 1;
            i = payloadSize;
        }
        else
        {
            charOccurredAt[currChar - 'a'] = currCharIndex;
        }
    }

    return markerBase;
}
}

file static class Input
{
    public const string String =
        "qvllndllhzhfzhhdzhddhjdjggvnvhvccmffwllqgqmmfjfqfhhtrrzczjczzlplddfpptqqfbqffmnmjnnqppfjfccgnnmqqsvvdbbgppjvpjvpjjctjjttwtrrdldlcddrvddqndqnqwqwzwfwwzczggcppgzpzhpzhppprfffbhhwmhhtftstrsrvsrvsrvvshvssnwwpllhfhnnfflcltlblzlqlvqlvlcldcccpptggtdgdjdbbrggmbmnncscbssqrrjddvcvgvfflpppgpvphvphhpcpzpzvvctvctvthtwtfwwbrrhhlplmlwwlqlnlhhtmhmmqlqplllrvrgvrvrffzfgfjfjtjmjvmjmwmvvjffmpfphfhvfvmfvmmhpphhltthgttgccqggpzpfpqpcpvcpvcvvqtqvqbbrlrtllmrmllhmhvmhhvzhvzvrrrzjzbbtvvbgvbbfnnqndqnnpnbnbnlnggwqggmgmqmgmbbmccgqcqbccpvcvnnhvvrvlrrcwrcwrcwrwbrwwzbwbdbfddpttntzzjszsnznbndnzngzgccjrcjchcffmlmqqlrqqzsqzzsbsnsttzpztpzpggzrrttbqqplpqlqjjqcqvccdzdccthccvfcvvqvhqhfhhzwzpzwppgpttntssflfjjrwrqrjrppptlltptpvttpfpwpswpppzzsrzssqllbnlljpllrjllsrlrhrdrmdrmrrpsrprnrffgrffdqdhdqhhrhggwqqlddsbsqbqtqdtdhdvhhbdhdzhdhhtrrppzddgfgzgpzpvpfpnpptggltggbnbppqffzfrzzzsbsrrdgrddwsdsqddhpdpbpvpfvppfsfgfngffzmzbzlblclsccvqvqmmjtjqtjjlcjllsddjqddhldlvlrrbgbrgbrrdzzpfpggqnqbqrrqbbgjgppqgpgwgqqndncndnpdnnbvbnvnwnjjgppzlplqqdgqghqgqzggjssqmmwwcfcpptrpprggrppgbplmzwmdtnpqwzcrthqbppwbgcvgqrpfpnbscnhvrllpvpqwnsslcjrqtvdccprvqfrpswtpvzdzlgtmmvppdmhgdbbsmrbqpqspdhpqgfjznqzphrnggcbzhdqrgvzcfzrhtrlssgmjjghqsjtghhnwjffqrrfslfnsvvdvfjqbfpffrrstdhggvbfwtfpfgswqlfdrnjpjmwzptlbmwgghgwqrphcrvfmhrplllgbnjlprllmjwccphsflntgpnbmdbfqcdsbgvrnfznfrlcfvswqfrqvdnbjsflnsmlcrdstzppmcvbgdtcvgztbdzqbwhmwcfvbwjjcdgbnwjwzrrdqhpgscwtnztjsfstzfwftcldjgvdvwbzrlbdslwttbqpnlwbjcjwqgtrgcglsgtdqbqbnqznptzzbwffwlwzvvtdpcjbvhnswzptclpbndcdvsfmcrmwwgzdfsszqjjdztmtsqgfqzjpctfdpwnzbpnzzwngqnghntblndfrnjzdrmgbqmzbdqfzctrgshwqgfgqssqjltrqlzjswjhmpgwwjdwcjpnsvgrvbfpmlmmwzmbdjwsrjthppfrccjgnmwlvqlprgslbwtbbzlqbznczmsmhsfdcqnwblprcpbzzwfllbnldvpjcwsdhglrzjsptmsjdjqzsmgvhjfjrrtvvbjlmzjsntnrggwbpjlrjggfgqzvswtggthzfmfjnmrzrttbzqpwpsnmdtnbfblpfgslgcmjlbdpshnnrbhvwsbrnvdmjqhvhdjhbfzjmqrmqmdthhzvnrmqcnbtwcdjdqfvdgvmfbhrfqnmdncrddggtcppjlznbsnntppjtnsqsrjwvfrzpnzqcrzhhdflfmmtmwcvtpzbqhdwsczffcqhtdbdjblmgnrmhlqcsvcpgghhvwqhdtzpzlpfllchzltqgcwgfqnbzhgzmdwqdlwnvhqmpqjqnjbhjctslghdqvctdmjfwdfpdjnhdndzwsfjzlmsbmfmzvnvpqgqhtngvgqmlrrzsfmwlcwsscvghjvrzjjqbnplnjzqswpblwzwczhwbhhnjmctnmwlbqqfmnlwdcrptlmfjpjrnpcvmhffjhwhmntdzpdjzwzhrrsdvmjlwdtcpvjfmfzfsrgjghhlvmjjjczgmhvrfpgqbnhldwbrjgzmnszzbssfzcggrwmdfvddwsdmnwtwfwlfnwlvzlctfblbtrjvcwjjdljplcrjhwqslppwwtvfqwsjlfmdznmcdzdmgvmmsrfcclcvhtrhlsjzrbjwrjlfnvqhqvmpzmdttnbhfcvnqlrqbcsvtvwfccjstjpmhqgwlnrzjjmfdszflmglrdbpqhqhqsdfzrcljbdvvnlcqfllmnqcjfzjppdsjwshfschzqbnwfqnpwhqnmwsjbtcgvrljsrtzvcvghcjjlqsngglcggqpntrrhbjpbfhmvpltmnfmfdtwnczwfbvjcqnhvppjftwvwsrlhvvcjtsfptpqgrmrqwwddnqmnmfgrlnphbpqhhhvglqgtwvnwvnbssftmwttmfrffwtzhrpqspclvgchwqwcsgwqwwvpgcwngrcfmhbhflwfbfchlphdzdcrflfmfclsngtlwrqcrsgrdzcpdsvvcdbhgtljmbntbbcqgjqfsbfwzlfsnljpjdcnmjlqrwpmlvwgdlrrdgfhdqhzgltmclzgzzhmrbggsmgtpqdrgmjtlzwstrwbpvhppvsmdqvvwwglzjgdswjszqmrdbmshbhhcstpcsjdbvgjnvcmvhbtclrlmlgnvppgvncsrfchdbqjrclwwlnchmcgvshfsbsvvcvjrsgjlnsfqtqmgntffwnqjtldcqbcqhsgztllstswwqnfrswpchqhnfzzzszqjztzfrgrbjdbjlpvqfqrlrmmpbfbbcclrgmnlzwqrjhqrstswjpgsrtnlwsbqthzpvdzllzqmdmbvvtcztftvlwphhjzbfnrvccfmhmvmzlbrzlnppfzcsffjvjmbgpvlwgwszpztjpsrbnftqtdrbnljtbrjzzbwlsvtwtlwptdtnmtncvcblcmdngjzmctlqtzchncccnwjzrrmmmnllbhrnhwtqjsnvcslrqjfbfndqvdlrjshdzmlprtzbtnhthdqhplwzdbnjmgzlzrbzrvrqnflwfmsmbssqnbcddnvdpltpmplpdzvtjrslcdcnrdplwtjtvctwfzhlvwwqqtbqcjjwhhnpmvgzhqmqfgthwbphrmrtdghchsmwghdqjgjgmpddbrtngtvhqgjfrplrdgpbnhqvswrmqhcmsqvsqmqsgwjndwjrbrhvrctmmrmfwpsgfgdlrzpslpflgvwrgcthgcrnhgrzsmqdgdssjgspfhmqfmjfpmwqhnfjdvqzhpndvnbmqglbrjmdrwgmgctrgzpsdvfbmcstcslblmvnprphntgslmlrqwthrndrhtbccgzzfsglhgqztcsnqjwfzbzlvrpbvswbhrwdsrhrrpnrmsbvbvjccbdsdcfrrzpgwjtnnnvjwlcppwzdqsbdzpfjplrlfgvjpsmbzwpwlghnvqgddfjvrsztrpzlfgmqqzrfcgglghndbhgbmldglclhldljjdslvhzshshtqwhqnbzhvqrcmwdmcmhjcrmdmhrwnwcbhvbbrwrbtfdnztwnbpdfjfhgrmcpngftsvbsmsptnwcvvllnmbnsntbzmwnhfdptbtzswtjzdqwjdhprnjwvhzpscjvlsgrhdrmmrmhzhwwtslzdjqmzfncnmgplhnmwrvqhslvchtjcmpzpjpnpfbjptvvwcsmhgdjtsqrjlfpnfdncpqqmpgpvtlvwljlsqbnhtsqgfwlsmdjpgtvgjvjcrnnzmbllqzlrfdnlffgmtphhhgbcjgdlpzqpwmjwtcmdrsmtnmddftwczbsddtppsptbwfvpnfnsqmsgcfqfmnzffzqgcdvwzrgdwhmnzmrlhcdpdsltnsmjzdqwmmpwvjqbbwsrfgzh";
}
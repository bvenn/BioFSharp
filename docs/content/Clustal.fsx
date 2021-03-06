
(*** hide ***)
// This block of code is omitted in the generated HTML documentation. Use 
// it to define helpers that you do not want to show in the documentation.
#I "../../bin"
#r "../../bin/BioFSharp.dll"
#r "../../bin/BioFSharp.IO.dll"
#r "../../bin/FSharp.Care.dll"
#r "../../bin/FSharp.Care.IO.dll"

(**
<table class="HeadAPI">
<td class="Head"><h1>Clustal format</h1></td>
<td class="API">
    <a id="APILink" href="https://csbiology.github.io/BioFSharp/reference/biofsharp-io-clustal.html" >&#128194;View module documentation</a>
<td>
</table>

The clustal file format is the standard output format of alignments generated by clustal algorithms (Clustal W, Clustal Omega...). Usually the first line is a one line header, including the clustal version and possibly other information. This is followed by at least one empty line.  
Afterwards there are blocks of sequence data. The amount of blocks depends on the length of the sequences. Every line in those blocks consists of: 
    
1. Name of Sequence  
2. White space  
3. Up to 60 characters of the sequence, where `-` denotes gaps  
4. (not necessarily) white space and a number stating the cumulative amount of non gap characters of the given sequence up to this point  

The last line of every block is a sequence of symbols denoting the degree of conservation for this column. (`*` = identical residues, `:` = conserved substitution, `.` = semi-conserved substitutions, ` ` = no match)  

Blocks are separated by at least one empty line.  
  
As an example, the peptide sequences of the large chain subunit of RuBisCO of different organisms was aligned with Clustal Omega:  
<br>
<button type="button" class="btn" data-toggle="collapse" data-target="#clustalExample">Show/Hide example</button>
<div id="clustalExample" class="collapse clustalExample ">
<pre>
CLUSTAL O(1.2.4) multiple sequence alignment<br>
<br>
<br>
C\_reinhardtii      MVPQTETKAGAGFKAGVKDYRLTYYTPDYVVRDTDILAAFRMTPQLGVPPEECGAAVAAE<br>
N\_tabacum          MSPQTETKASVGFKAGVKEYKLTYYTPEYQTKDTDILAAFRVTPQPGVPPEEAGAAVAAE<br>
A\_thaliana         MSPQTETKASVGFKAGVKEYKLTYYTPEYETKDTDILAAFRVTPQPGVPPEEAGAAVAAE<br>
O\_sativa           MSPQTETKASVGFKAGVKDYKLTYYTPEYETKDTDILAAFRVTPQPGVPPEEAGAAVAAE<br>
                    \* \*\*\*\*\*\*\*..\*\*\*\*\*\*\*:\*:\*\*\*\*\*\*:\* .:\*\*\*\*\*\*\*\*\*:\*\*\* \*\*\*\*\*\*.\*\*\*\*\*\*\*<br>
<br>
C\_reinhardtii      SSTGTWTTVWTDGLTSLDRYKGRCYDIEPVPGEDNQYIAYVAYPIDLFEEGSVTNMFTSI<br>
N\_tabacum          SSTGTWTTVWTDGLTSLDRYKGRCYRIERVVGEKDQYIAYVAYPLDLFEEGSVTNMFTSI<br>
A\_thaliana         SSTGTWTTVWTDGLTSLDRYKGRCYHIEPVPGEETQFIAYVAYPLDLFEEGSVTNMFTSI<br>
O\_sativa           SSTGTWTTVWTDGLTSLDRYKGRCYHIEPVVGEDNQYIAYVAYPLDLFEEGSVTNMFTSI<br>
                    \*\*\*\*\*\*\*\*\*\*\*\*\*\*\*\*\*\*\*\*\*\*\*\*\* \*\* \* \*\*. \*:\*\*\*\*\*\*\*:\*\*\*\*\*\*\*\*\*\*\*\*\*\*\*<br>
<br>
C\_reinhardtii      VGNVFGFKALRALRLEDLRIPPAYVKTFVGPPHGIQVERDKLNKYGRGLLGCTIKPKLGL<br>
N\_tabacum          VGNVFGFKALRALRLEDLRIPPAYVKTFQGPPHGIQVERDKLNKYGRPLLGCTIKPKLGL<br>
A\_thaliana         VGNVFGFKALAALRLEDLRIPPAYTKTFQGPPHGIQVERDKLNKYGRPLLGCTIKPKLGL<br>
O\_sativa           VGNVFGFKALRALRLEDLRIPPTYSKTFQGPPHGIQVERDKLNKYGRPLLGCTIKPKLGL<br>
                    \*\*\*\*\*\*\*\*\*\* \*\*\*\*\*\*\*\*\*\*\*:\* \*\*\* \*\*\*\*\*\*\*\*\*\*\*\*\*\*\*\*\*\* \*\*\*\*\*\*\*\*\*\*\*\*<br>
<br>
C\_reinhardtii      SAKNYGRAVYECLRGGLDFTKDDENVNSQPFMRWRDRFLFVAEAIYKAQAETGEVKGHYL<br>
N\_tabacum          SAKNYGRAVYECLRGGLDFTKDDENVNSQPF-RWRDRFLFCAEALYKAQAETGEIKGHYL<br>
A\_thaliana         SAKNYGRAVYECLRGGLDFTKDDENVNSQPFMRWRDRFLFCAEAIYKSQAETGEIKGHYL<br>
O\_sativa           SAKNYGRACYECLRGGLDFTKDDENVNSQPFMRWRDRFVFCAEAIYKSQAETGEIKGHYL<br>
                     \*\*\*\*\*\*\*\* \*\*\*\*\*\*\*\*\*\*\*\*\*\*\*\*\*\*\*\*\*\* \*\*\*\*\*\*:\* \*\*\*:\*\*:\*\*\*\*\*\*:\*\*\*\*\*<br>
<br>
C\_reinhardtii      NATAGTCEEMMKRAVCAKELGVPIIMHDYLTGGFTANTSLAIYCRDNGLLLHIHRAMHAV<br>
N\_tabacum          NATAGTCEEMIKRAVFARELGVPIVMHDYLTGGFTANTSLAHYCRDNGLLLHIHRAMHAV<br>
A\_thaliana         NATAGTCEEMIKRAVFARELGVPIVMHDYLTGGFTANTSLSHYCRDNGLLLHIHRAMHAV<br>
O\_sativa           NATAGTCEEMIKRAVFARELGVPIVMHDYLTGGFTANTSLAHYCRDNGLLLHIHRAMHAV<br>
                    \*\*\*\*\*\*\*\*\*\*:\*\*\*\* \*:\*\*\*\*\*\*:\*\*\*\*\*\*\*\*\*\*\*\*\*\*\*: \*\*\*\*\*\*\*\*\*\*\*\*\*\*\*\*\*\*<br>
<br>
C\_reinhardtii      IDRQRNHGIHFRVLAKALRMSGGDHLHSGTVVGKLEGEREVTLGFVDLMRDDYVEKDRSR<br>
N\_tabacum          IDRQKNHGIHFRVLAKALRMSGGDHIHSGTVVGKLEGERDITLGFVDLLRDDFVEQDRSR<br>
A\_thaliana         IDRQKNHGMHFRVLAKALRLSGGDHIHAGTVVGKLEGDRESTLGFVDLLRDDYVEKDRSR<br>
O\_sativa           IDRQKNHGMHFRVLAKALRMSGGDHIHAGTVVGKLEGEREMTLGFVDLLRDDFIEKDRAR<br>
                    \*\*\*\*:\*\*\*:\*\*\*\*\*\*\*\*\*\*:\*\*\*\*\*:\*:\*\*\*\*\*\*\*\*\*:\*: \*\*\*\*\*\*\*:\*\*\*::\*:\*\*:\*<br>
<br>
C\_reinhardtii      GIYFTQDWCSMPGVMPVASGGIHVWHMPALVEIFGDDACLQFGGGTLGHPWGNAPGAAAN<br>
N\_tabacum          GIYFTQDWVSLPGVLPVASGGIHVWHMPALTEIFGDDSVLQFGGGTLGHPWGNAPGAVAN<br>
A\_thaliana         GIFFTQDWVSLPGVLPVASGGIHVWHMPALTEIFGDDSVLQFGGGTLGHPWGNAPGAVAN<br>
O\_sativa           GIFFTQDWVSMPGVIPVASGGIHVWHMPALTEIFGDDSVLQFGGGTLGHPWGNAPGAAAN<br>
                    \*\*:\*\*\*\*\* \*:\*\*\*:\*\*\*\*\*\*\*\*\*\*\*\*\*\*\*.\*\*\*\*\*\*: \*\*\*\*\*\*\*\*\*\*\*\*\*\*\*\*\*\*.\*\*<br>
<br>
C\_reinhardtii      RVALEACTQARNEGRDLAREGGDVIRSACKWSPELAAACEVWKEIKFEFDTIDKL----<br>
N\_tabacum          RVALEACVKARNEGRDLAQEGNEIIREACKWSPELAAACEVWKEIVFNFAAVDVLDK--<br>
A\_thaliana         RVALEACVQARNEGRDLAVEGNEIIREACKWSPELAAACEVWKEITFNFPTIDKLDGQE<br>
O\_sativa           RVALEACVQARNEGRDLAREGNEIIRSACKWSPELAAACEIWKAIKFEFEPVDKLDS--<br>
                    \*\*\*\*\*\*\*.:\*\*\*\*\*\*\*\*\* \*\*.::\*\*.\*\*\*\*\*\*\*\*\*\*\*\*\*:\*\* \* \*:\*  :\* \*    
</pre>

<button type="button" class="btn" data-toggle="collapse" data-target="#clustalExample">Hide again</button>  
</div>


## Reading Clustal files

To read Clustal files, just use the ofFile function located in the Clustal module of the BioFSharp.IO namespace. It does not need anything but the file path and will return the alignment as `Alignment`.  
Keep in mind that if your clustal file containts numbers representing the character count at the line end. They and their line space will be included in the Alignment. Make sure to filter them out if not needed.

*)

open BioFSharp.IO

let fileDir = __SOURCE_DIRECTORY__ + "/data/"

let path = fileDir + "clustalExample.asn"

let clustalAlignment = Clustal.ofFile path

(**
<pre>
val clustalAlignment :
  BioFSharp.Alignment.Alignment<Clustal.NamedSequence,Clustal.AlignmentInfo> =
  {MetaData = {Header = &lt;seq&gt;;
               ConservationInfo = &lt;seq&gt;;};
   AlignedSequences =
    [{Name = "C_reinhardtii";
      Sequence = &lt;seq&gt;;}; {Name = "N_tabacum";
                           Sequence = &lt;seq&gt;;}; {Name = "A_thaliana";
                                                Sequence = &lt;seq&gt;;};
     {Name = "O_sativa";
      Sequence = &lt;seq&gt;;}];}
</pre>
## Writing Clustal files

For writing clustal files you can use the `toFile` function. It takes a path and the alignment. The type of alignment is the same as the result of the reading function. You can see this above.

*)
let outputPath = fileDir + "clustalOutputExample.asn"

Clustal.toFileWithOverwrite outputPath clustalAlignment
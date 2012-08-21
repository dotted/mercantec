# http://powershell.com/cs/media/p/151.aspx
$i=$j=$r=$x=$y=[float]-16; 
$colors="Black","DarkBlue","DarkGreen","DarkCyan","DarkRed","DarkMagenta","DarkYellow","Gray","DarkGray","Blue","Green","Cyan","Red","Magenta","Yellow","White"
while(($y++) -lt 15) {
    for($x=0; ($x++) -lt 84; 
        write-host " " -backgroundcolor ($colors[$k -band 15]) -nonewline) {
        $i=$k=$r=[float]0;
        do{$j=$r*$r-$i*$i-2+$x/25;$i=2*$r*$i+$y/10;$r=$j} 
        while (($j*$j+$i*$i) -lt 11 -band ($k++) -lt 111)
    }
    " "
}
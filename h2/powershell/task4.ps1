Set-ExecutionPolicy Unrestricted -scope Process

# Microsoft are either idiots or are smoking a lot of weed
$shell = (Get-Host).UI.RawUI
$shell.WindowTitle = "Scriptprogrammerings opgave"
$shell.BackgroundColor = "black"
$shell.ForegroundColor = "white"

$my_documents = $HOME + "\Documents\"
$lab_output   = $my_documents + "LabOutput\"

function clean_up()
{
    $shell.WindowTitle = "Scriptprogrammerings opgave - Clean up"
    if (Test-Path $my_documents+"MyDir.txt") { rm $my_documents+"MyDir.txt" }
    if (Test-Path $my_documents+"WindowsDir.txt") { rm $my_documents+"WindowsDir.txt" }
    if (Test-Path $my_documents+"Procs.txt") { rm $my_documents+"Procs.txt" }
    if (Test-Path $lab_output) { rm -r $lab_output }
}

function task_1()
{
    $shell.WindowTitle = "Scriptprogrammerings opgave - Task 1"
    echo "Task 1 - Create a text file that contains the names of the files and folders in C:\Windows. Name the text file MyDir.txt."
    dir C:\Windows > $my_documents+"MyDir.txt"
    echo "Echoed 'dir C:\Windows' to '$my_documents MyDir.txt'"
}
function task_2()
{
    $shell.WindowTitle = "Scriptprogrammerings opgave - Task 2"
    echo "Tast 2 - Display the contents of that text file."
    cat $my_documents+"MyDir.txt"
}

function task_3()
{
    $shell.WindowTitle = "Scriptprogrammerings opgave - Task 3"
    echo "Task 3 - Rename the file from MyDir.txt to WindowsDir.txt."
    mv $my_documents+"MyDir.txt" $my_documents+"WindowsDir.txt"
    echo "Renamed 'MyDir.txt' to 'WindowsDir.txt'"
}

function task_4()
{
    $shell.WindowTitle = "Scriptprogrammerings opgave - Task 4"
    echo "Task 4 - Create a new folder named LabOutput you can either do this in your Documents folder, or in the root of your C: drive."
    mkdir $lab_output
    echo "Created folder '$lab_output'"
}

function task_5()
{
    $shell.WindowTitle = "Scriptprogrammerings opgave - Task 5"
    echo "Task 5 - Copy WindowsDir.txt into the LabOutput folder."
    cp $my_documents+"WindowsDir.txt" $lab_output
    echo "Copied 'WindowsDir.txt' to '$lab_output'"
}

function task_6()
{
    $shell.WindowTitle = "Scriptprogrammerings opgave - Task 6"
    echo "Task 6 - Delete the original copy of WindowsDir.txt not the copy that you just made in LabOutput."
    rm $my_documents+"WindowsDir.txt"
    echo "Deleted '$my_documents WindowsDir.txt'"
}

function task_7()
{
    $shell.WindowTitle = "Scriptprogrammerings opgave - Task 7"
    echo "Task 7 - Display a list of running processes."
    ps
}

function task_8()
{
    $shell.WindowTitle = "Scriptprogrammerings opgave - Task 8"
    echo "Task 8 - Redirect a list of running processes into a file named Procs.txt."
    ps > $my_documents+"Procs.txt"
    echo "Saved list of currently running processes to '$my_documents Procs.txt'"
}

function task_9()
{
    $shell.WindowTitle = "Scriptprogrammerings opgave - Task 9"
    echo "Task 9 - Move Procs.txt into the LabOutput folder if it isn’t in there already."

    if (!(Test-Path $lab_output+"Procs.txt"))
    {
        echo "'Procs.txt' not found in LabOutput folder"
        mv $my_documents+"Procs.txt" $lab_output
        echo "'Procs.txt' moved to '$lab_output'"
    }
    else { echo "Procs.txt was already found in '$lab_output', did clean up fail last run?" }
}

function task_10()
{
    $shell.WindowTitle = "Scriptprogrammerings opgave - Task 10"
    echo "Task 10 - Display the contents of Procs.txt  so that only one page displays at a time."
    cat $lab_output+"Procs.txt" | more
}

clean_up
task_1
task_2
task_3
task_4
task_5
task_6
task_7
task_8
task_9
task_10
clean_up
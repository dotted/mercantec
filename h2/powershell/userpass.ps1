$Global:passwordPath = $("$env:APPDATA\dotuserpass.xml")
$Global:passwordXml = @()
$Global:passwordXml["dotted"] = "CF-83-E1-35-7E-EF-B8-BD-F1-54-28-50-D6-6D-80-07-D6-20-E4-05-0B-57-15-DC-83-F4-A9-21-D3-6C-E9-CE-47-D0-D1-3C-5D-85-F2-B0-FF-83-18-D2-87-7E-EC-2F-63-B9-31-BD-47-41-7A-81-A5-38-32-7A-F9-27-DA-3E", "CF-83-E1-35-7E-EF-B8-BD-F1-54-28-50-D6-6D-80-07-D6-20-E4-05-0B-57-15-DC-83-F4-A9-21-D3-6C-E9-CE-47-D0-D1-3C-5D-85-F2-B0-FF-83-18-D2-87-7E-EC-2F-63-B9-31-BD-47-41-7A-81-A5-38-32-7A-F9-27-DA-3E"

<#
@param $input: String input to hash
#>
function sha512($input)
{
    $sha512 = new-object -TypeName System.Security.Cryptography.SHA512CryptoServiceProvider
    $utf8 = new-object -TypeName System.Text.UTF8Encoding
    $hash = [System.BitConverter]::ToString($sha512.ComputeHash($utf8.GetBytes($input)))

    return $hash
}

<#
@param $password: String input to hash
@param $salt: Password salt to counter dictionary attacks
@param $iterations: Number of iteration to perform on input, more interations more security, defaults to 4096
#>
function get_password_hash([string]$password, [string]$salt, [int]$iterations = 4096)
{
    #Make sure iteratons are always positive numbers
    $iterations = [math]::abs($iterations)

    foreach ($i in 1..$iterations)
    {
        if ($i -eq 1)
        {
            $result = sha512 $password+$salt
        }
        else
        {
            $result = sha512 $result
        }
    }
    return $result
}
<#
Unserialize xml into object
#>
function load_passwords()
{
    try
    {
        $Global:passwordXml = Import-Clixml -path $Global:passwordPath
        return $true
    }
    catch
    {
        return $false
    }
}

<#
Serialize object and store in xml
#>
function save_passwords()
{
    try
    {
        Export-Clixml -InputObject $Global:passwordXml -Path $Global:passwordPath -Force
        return $true
    }
    catch
    {
        return $false
    }
}

function create_user([string]$username, [string]$password)
{
        $salt = sha512 Get-Random
        $password_hash = get_password_hash $password, $salt
        $Global:passwordXml["$username"] = ("$salt", "$password_hash")
}
echo "l"
param
(
    [Parameter(Position = 0, Mandatory = $true)]
    [string]$targetFramework,
    [Parameter(Position = 1)]
    [string]$indexPageName = 'index',
    [Parameter(Position = 2)]
    [string]$readmeUrl = 'https://bitbucket.org/miholler/dotfluent/wiki'
)

Get-ChildItem .\source | Remove-Item -Recurse -Force

xmldoc2md ..\src\DotFluent\bin\Debug\$targetFramework\DotFluent.dll -o .\source --index-page-name $indexPageName --back-button --github-pages

$insertIndex = 2;
$indexPath = ".\source\$indexPageName.md";
$readmePath = '..\README.md';

if (Test-Path $indexPath) {
    $lines = Get-Content $indexPath

    if ($lines.Length -gt $insertIndex) {
        $subheading = Get-Content .\subheading.md -Raw
        $footer = Get-Content .\footer.md -Raw
        $lines = $lines[0..($insertIndex - 1)] + $subheading + $lines[($insertIndex - 1)..($lines.Length - 1)] + $footer
        $lines | Set-Content $indexPath

        Copy-Item $indexPath -Destination $readmePath
        (Get-Content $readmePath).Replace('(.', "($readmeUrl") | Set-Content $readmePath
    }
}
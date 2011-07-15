# WatcherAndCommander

## Description
WatcherAndCommander is an application for Windows which watches file system
directories for changes, and runs commands using `cmd.exe`.

## Setup
Each *Commander* is configured with a number of directories, a list of
commands, an optional working directory and an optional file filter. See
[Setup_Commander.png][setup commander] for reference in the following.
*Paths* are monitoried recursively for creation, deletion, renames and
changes. *Commands* are separated by newlines, and are executed one by one
using `cmd.exe /c`. *Filters* is a [regular expression] towards which the full
path of the changed file is matched. *Working Directory* determines from
which directory commands are run. If *Working Directory* is unset, commands
are run from the current working directory.

## Expansions
*Commands* accepts several macro expansions:

<table>
<tr><td><tt>${path}</tt></td><td>Full path of the changed file</td></tr>
<tr><td><tt>${relpath}</tt></td><td>Path of the changed file relative to the <em>Working Directory</em></td></tr>
<tr><td><tt>${name}</tt></td><td>Name of the changed file</td></tr>
<tr><td><tt>${directory}</tt></td><td>Directory of the changed file</td></tr>
</table>

For renamed files, there are also macro expansions for the old path of the file,
i.e. the path before the rename operation:

<table>
<tr><td><tt>${oldpath}</tt></td><td>Full path of the original file</td></tr>
<tr><td><tt>${oldrelpath}</tt></td><td>Path of the original file relative to the <em>Working Directory</em></td></tr>
<tr><td><tt>${oldname}</tt></td><td>Name of the original file</td></tr>
<tr><td><tt>${olddirectory}</tt></td><td>Directory of the original file</td></tr>
</table>

To facilitate certain operations on paths, the macros also have modifiers.
Macro modifiers take the form `${<modifier(s)>:<macro>}`. For example to
escape characters in the relative path such that it is suitable for a regular
expression, one can use the macro `${e:relpath}`. These are the macro
modifiers that are currently supported:

<table>
<tr><td><tt>${e:&lt;macro&gt;}</tt></td><td>Replace <tt>\</tt> and <tt>.</tt> with <tt>\\</tt> and <tt>\.</tt> respectively</td></tr>
</table>

## Disclaimer
This project was created to satsify a personal need to automatically update
`tags`-files with `ctags`, and to satisfy a curiosity for the C# language.
Therefore it is neither as feature complete as I would wish, nor as well
written.

I have tried to follow best practices for C# where I have found them, but I
come from a C++ background and this probably shows in the code. Feel free to
fork and improve the code, and educate me where I have gone wrong.

There are probably a lot of corner cases that I have missed, and exceptions I
should have caught. If you find a problem, write an issue report or submit a
pull request.

## TODO
1. Add an option to disable recursive monitoring of directories
2. Add more macro modifiers
3. Improve logging: add better support for viewing stdout and stderr from
   commands.
4. Add a notification to the *Commander* list to indicate when a file has
   been changed. (I.e. temporarily change the colour of the commander name.)
5. Improve documentation
6. Do some proper testing


[regular expression]: http://msdn.microsoft.com/en-us/library/az24scfc.aspx
[setup commander]: https://github.com/spiiph/WatcherAndCommander/blob/master/Setup_Commander.png

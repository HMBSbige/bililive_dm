MSBuild /nologo /verbosity:m /maxcpucount /p:Configuration="Debug",Platform="Win32" "../libwtfdanmaku/libwtfdanmaku.vcxproj"
MSBuild /nologo /verbosity:m /maxcpucount /p:Configuration="Debug",Platform="x64" "../libwtfdanmaku/libwtfdanmaku.vcxproj"
copy ..\libwtfdanmaku\Debug\Win32\*.dll ..\Bililive_dm\Win32\
copy ..\libwtfdanmaku\Debug\x64\*.dll ..\Bililive_dm\x64\
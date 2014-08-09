
@echo off
ECHO.
ECHO.
ECHO *********************************************************
ECHO 		.NET DLL Squeaky Clean Script V1.0.0
ECHO 			by Bradley Van Aardt
ECHO 			theminidriver@gmail.com
ECHO *********************************************************
ECHO.


REM Clean each sub-folder in 'src'. 
cd src
for /D %%d in (*) do call "_remove_output_directories.bat" %%d
cd ..

ECHO You have been using: 
ECHO.			
ECHO *********************************************************
ECHo		.NET DLL Squeaky Clean Script V1.0.0
ECHO 			by Bradley Van Aardt
ECHO 			theminidriver@gmail.com
ECHO *********************************************************
ECHO.
ECHO.

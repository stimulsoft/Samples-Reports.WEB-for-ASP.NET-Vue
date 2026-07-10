cd ClientApp
call npm i
call npx vite build
xcopy /E /Y dist\* ..\wwwroot\
cd ..

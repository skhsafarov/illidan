git checkout main
git add *
git commit -m "saved master branch"
git push


# удалить в папке ".published/illidan/" все файлы и папки, кроме папки ".git"
Remove-Item -Path .published/illidan/* -Exclude .git -Recurse -Force

dotnet publish -c Release -o .published/illidan

# cd .published/illidan
# git checkout gh-pages
# git add *
# git commit -m "published gh-pages branch"
# git push
# cd ../../
# How to use git
Clone the repo
```
git clone git@github.com:xDragy/Project5-6.git
```

Switch to your branch
```
git checkout -b <your-branch>
```

Get latest changes
```
git fetch
```

Merge the latest changes with your branch
```
git checkout main
git pull origin main

git checkout <your-branch>
git merge main
```

Adding files
```
git add <filename>
```

Commit your latest changes
```
git commit <file> -m "<commit message>"
```

Push your latest commits
```
git push
```

Merging with the main branch
```
git checkout main
git pull origin main
git merge <your-branch>
```

Any merge conflicts
```
You can try to fix them yourself, or mention someone else so that they can help you with the merge
```
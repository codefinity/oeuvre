### Create a New Branch


git checkout -b &lt;new-branch&gt; &lt;existing-branch&gt;


### Switch Branch

git checkout &lt;branchname&gt;

git checkout -b &lt;new-branch&gt; &lt;existing-branch&gt;


### Stash all including UnTraced files

git stash --include-untracked

### List all branches

#### list all branches in local and remote repositories is

git branch -a

#### Only list the remote branches

git branch -r

### Merge a branch

git checkout &lt;branch-to-merge-to&gt;
git merge &lt;branch-to-merge-with&gt;


### Push new changes to a new branch

git checkout -b &lt;your-new-branch&gt;

git add .

git commit -m &lt;message&gt;

git push origin &lt;your-new-branch&gt;

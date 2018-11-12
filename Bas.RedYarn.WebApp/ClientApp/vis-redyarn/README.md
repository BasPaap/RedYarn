# BasRedyarnWebapp
This is a custom build of [VisJS](http://github.com/almende/visjs) (cloned at commit [5563fc6](https://github.com/almende/vis/commit/5563fc616885578ad51b2dfa6ccf70ccebf06126)). Currently, the normal build has a version of Network that does not propagate mouse events upwards to the containing element. This makes it impossible to capture mouseup and mousedown events. 

A solution is to comment out the line `preventDefault: 'mouse'` (see the discussion in the relevant [issue](https://github.com/almende/vis/issues/2525)) in hammer.js. This does not appear to have noticeable side effects.

The build included in this project is a build of visjs with the relevant line commented out, and includes a definition file for Typescript types. It is added as a local package in package.json (`"vis-redyarn": "file:vis-redyarn",`), via a symlink to the build directory (Clientapp\vis-redyarn) in node_modules.

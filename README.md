# Mesh Cutout Unity

<p><a target="_blank" rel="noopener noreferrer" href="https://camo.githubusercontent.com/abcf7bd8842b8a54ef3b570e76c3b4478f481292d0b43ffc9c43104a39fd8196/68747470733a2f2f696d672e736869656c64732e696f2f62616467652f756e6974792d323032302e332d677265656e2e7376673f7374796c653d666c61742d737175617265"><img src="https://camo.githubusercontent.com/abcf7bd8842b8a54ef3b570e76c3b4478f481292d0b43ffc9c43104a39fd8196/68747470733a2f2f696d672e736869656c64732e696f2f62616467652f756e6974792d323032302e332d677265656e2e7376673f7374796c653d666c61742d737175617265" alt="unity 2020.3" data-canonical-src="https://img.shields.io/badge/unity-2020.3-green.svg?style=flat-square" style="max-width: 100%;"></a></p>

<p><a target="_blank" rel="noopener noreferrer" href="https://camo.githubusercontent.com/02d95570ab6a8f7d96171f63e38f763f6b994fc3548e225ff018795b136bf8ac/68747470733a2f2f696d672e736869656c64732e696f2f62616467652f756e6974792d323032312e332d677265656e2e7376673f7374796c653d666c61742d737175617265"><img src="https://camo.githubusercontent.com/02d95570ab6a8f7d96171f63e38f763f6b994fc3548e225ff018795b136bf8ac/68747470733a2f2f696d672e736869656c64732e696f2f62616467652f756e6974792d323032312e332d677265656e2e7376673f7374796c653d666c61742d737175617265" alt="unity 2021.3" data-canonical-src="https://img.shields.io/badge/unity-2021.3-green.svg?style=flat-square" style="max-width: 100%;"></a></p>


<b>Mesh Cutout</b> is a simple asset used to generate meshes/cutouts based on the distance to an object at runtime in a performant manner. 

Supported in ALL graphics pipelines, since the tool modifies the mesh data directly.

# Import
- Go to Package Manager
- Go to Add Package from Git URL
![image](https://user-images.githubusercontent.com/41569500/183402029-daddf2ff-1f03-4535-ab05-dcff87f18eed.png)
- Add 'https://github.com/smitdylan2001/com.devdunkstudio.meshcutout.git'
- Click <i>Add</i>


# How To Use

- Make sure the meshes used for Mesh Cutout have ‘Read/Write Enabled’ on. 
![image](https://user-images.githubusercontent.com/41569500/183391552-30397ef5-812a-4c65-8103-b0b63d8e78ce.png)

- Put ‘CutoutMesh.cs’ on an object with a MeshFilter component
![image](https://user-images.githubusercontent.com/41569500/183391631-b14a281a-4ccb-48e8-afb5-08133a9b1775.png)

- Change Cutout mode to desired mode

- Add Reference Object transform (can be left empty if manually calling <i>CutoutMesh.UpdateCarvedMesh();</i>)

- Configure the minimum and maximum distances

- Enable <i>Generate on Start</i> to generate the cutout immediately on start

- Enable <i>Generate on Update</i> to generate the cutout every frame

- Enable <i>Generate on FixedUpdate</i> to generate the cutout every FixedUpdate interval 

- To manually trigger the meshing call <i>CutoutMesh.UpdateCarvedMesh();</i> (required a ReferenceObject Transform if not filled in inspector)



# Demo

- Simple cutout (enclosing)
![image](https://user-images.githubusercontent.com/41569500/183393490-ddf8836b-f58b-43b1-8da8-d0c0d3146723.png)
- Simple cutout with hole (enclosing)
![image](https://user-images.githubusercontent.com/41569500/183393609-2bf11af5-a93d-466a-a77a-e7b756466b5d.png)
- Simple cutout with hole (touching)
![image](https://user-images.githubusercontent.com/41569500/183393708-b6dcbe9a-d78b-419c-8d57-31d0cad8c6a2.png)
- Complex mesh with cutout (touching)
![image](https://user-images.githubusercontent.com/41569500/183393868-506ee34b-f2a5-4a87-9186-1baa6c61d546.png)
- Complex mesh with cutout and hole (touching)
![image](https://user-images.githubusercontent.com/41569500/183394051-0d656288-ba4c-435a-9301-e2dae5586aff.png)
- Complex mesh with cutout and hole (enclosing)
![image](https://user-images.githubusercontent.com/41569500/183394717-8929ccf3-cbfe-44df-aa3a-3cc872dc83a1.png)


# Limitations

- Currently only 1 reference object is supported
- Code runs on main thread (could potentially be faster with job system/burst support)
- <i>Read/Write Enabled</i> has to be enabled resulting in more memory allocation
- Could Potentially use MeshData for more performance: <a>https://docs.unity3d.com/2020.1/Documentation/ScriptReference/Mesh.MeshData.html</a>



# How to contribute

- All contributions for flexibility, performance and usability are welcome
- Follow code conventions from <i>CutoutMesh.cs</i>
- For changes in functionality (such as multiple reference objects), make a new script
- Potential contributions: 
  - Performance optimization
  - multithread support (jobified for loop and/or 1 job per meshed object)
  - run in editor
  - cutout preview system
  - Multiple reference objects support
  - Update Mesh Collider



# Special Credits:
Bunny83 on Unity Forums for writing most of the script:
https://forum.unity.com/threads/loop-through-triangles-performance-issue.1280498  

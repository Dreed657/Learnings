let scene, camera, renderer, controls;

function init() {
  //   canvas = document.querySelector("#c");
  renderer = new THREE.WebGLRenderer();
  renderer.setSize(window.innerWidth, window.innerHeight);
  document.body.appendChild(renderer.domElement);

  scene = new THREE.Scene();
  scene.background = new THREE.Color("grey");
  scene.add(new THREE.AxesHelper(500));

  const fov = 75;
  const aspect = 2;
  const near = 0.000000001;
  const far = 500;
  camera = new THREE.PerspectiveCamera(fov, aspect, near, far);
  camera.position.set(0, 20, 50);

  controls = new THREE.OrbitControls(camera, renderer.domElement);

  hemiLight = new THREE.HemisphereLight("black", "orange", 4);
  scene.add(hemiLight);

//   new THREE.GLTFLoader().load("models/testGltf/scene.gltf", (gltf) => {
//     scene.add(gltf.scene);
//   });

  new THREE.GLTFLoader().load("models/animation/scene.gltf", (gltf) => {
    scene.add(gltf.scene);
  });



//   const mtlloader = new THREE.MTLLoader();
//   mtlloader.load('models/testObj/Whitty Preview.mtl', (mtl) => {
//     mtl.preload();
//     const objloader = new THREE.OBJLoader();
//     objloader.setMaterials(mtl);
//     objloader.load("models/testObj/Whitty Preview.obj", (root) => {
//       scene.add(root);
//     });
//   });

  animate();
}
function animate() {
  renderer.render(scene, camera);
  requestAnimationFrame(animate);
}
init();

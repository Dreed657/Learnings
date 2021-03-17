import React from 'react';
import { useLoader } from 'react-three-fiber';
import { GLTFLoader } from 'three/examples/jsm/loaders/GLTFLoader';

const GLTFTest = () => {
    const { nodes, materials } = useLoader(
        GLTFLoader,
        'models/testGltf/scene.gltf'
    );

    console.log('Scene: ', { nodes, materials });

    return (
        <mesh
            geometry={nodes['Sketchfab_Scene']}
        />
    );
};

export default GLTFTest;

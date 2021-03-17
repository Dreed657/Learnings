import React, { Suspense } from 'react';
import { Canvas } from 'react-three-fiber';

import Controls from './components/controls';
import Loading from './components/loading';
import Model from './components/GLTFTest';
// import Mesh from './components/mesh';

import './App.css';

const App = () => {
    return (
        <div className="App">
            <Canvas style={{ background: '#171717' }}>
                <directionalLight intensity={0.5} />
                <Suspense fallback={<Loading />}>
                    <Model />
                </Suspense>
                <Controls
                    autoRotate
                    enablePan={false}
                    enableZoom={false}
                    enableDamping
                    dampingFactor={0.5}
                    rotateSpeed={1}
                    maxPolarAngle={Math.PI / 2}
                    minPolarAngle={Math.PI / 2}
                />
            </Canvas>
        </div>
    );
};

export default App;

'use client'

import { useRef } from 'react'
import { Canvas, useFrame } from '@react-three/fiber'
import { Sphere, MeshDistortMaterial } from '@react-three/drei'

function AnimatedSphere() {
  const meshRef = useRef<THREE.Mesh>(null!)

  useFrame((state) => {
    const t = state.clock.getElapsedTime()
    meshRef.current.rotation.x = Math.cos(t / 4) / 2
    meshRef.current.rotation.y = Math.sin(t / 4) / 2
    meshRef.current.rotation.z = Math.sin(t / 1.5) / 2
    meshRef.current.position.x = Math.sin(t / 1.5) / 2
    meshRef.current.position.y = Math.cos(t / 2) / 2
  })

  return (
    <Sphere args={[1, 100, 200]} ref={meshRef}>
      <MeshDistortMaterial
        color="#8352FD"
        attach="material"
        distort={0.3}
        speed={1.5}
        roughness={0}
      />
    </Sphere>
  )
}

export default function BackgroundScene() {
  return (
    <div className="fixed inset-0 -z-10">
      <Canvas camera={{ position: [0, 0, 5] }}>
        <ambientLight intensity={0.5} />
        <directionalLight position={[10, 10, 5]} />
        <AnimatedSphere />
      </Canvas>
    </div>
  )
}


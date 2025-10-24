# 🌍 Procedural Terrain Generation & Pathfinding in Unity

A Unity-based project demonstrating **procedural terrain generation** using **Perlin Noise** and **pathfinding visualization** using the **A* (A-star)** algorithm.
The project generates dynamic terrains with adjustable parameters and enables visualized shortest-path computation between two points on the generated landscape.

---

## 🧠 Overview

This project is a combination of two core systems:

1. **Procedural Terrain Generation**

   * Uses layered Perlin noise to create realistic terrain heightmaps.
   * Supports adjustable scale, octaves, persistence, and lacunarity.
   * Terrain rendered as a 3D mesh with color mapping based on height regions (e.g., water, sand, grass, mountains).

2. **A* Pathfinding Algorithm**

   * Visualizes pathfinding between two points on the generated terrain.
   * Accounts for elevation and terrain type (different traversal costs).
   * Demonstrates heuristic-based optimal pathfinding on an irregular surface.

---

## 🧩 Features

* 🗺️ Procedural terrain mesh generation with adjustable noise parameters
* 🎨 Color mapping for different terrain regions
* 🧮 Smooth height interpolation using AnimationCurves
* 🚶 Pathfinding visualization using A* algorithm
* 🧱 Configurable traversal costs for different terrain types
* 🧑‍💻 Modular, well-structured C# scripts (MapGenerator, MeshGenerator, TextureGenerator, Noise, etc.)
* ⚙️ Editor tools for auto-updating terrain in the Unity Inspector
---

## 🧮 Technical Concepts

### Procedural Terrain

* Terrain heights are generated using **Perlin Noise** layered over multiple octaves.
* Each octave increases **frequency** (detail) and decreases **amplitude** (height variation).
* The final heightmap is normalized and used to deform a flat mesh.
* Colors are mapped according to predefined `TerrainType` thresholds.

### Mesh Generation

* A **mesh** is constructed using vertex and triangle data from the heightmap.
* **UV mapping** ensures textures are scaled properly across the mesh.
* **Normals** are recalculated for correct lighting and shading.

### Pathfinding (A*)

* Grid-based pathfinding implemented with **open** and **closed** sets.
* The **cost** function considers distance and terrain type.
* Diagonal movement and height-based penalties are supported.
* Final path is drawn dynamically in the Unity Scene.

---

## 🧰 How to Use

1. Clone this repository

   ```bash
   git clone [https://github.com/whoami-pratyush/unity-procedural-landmass-pathfinding.git]
   ```

2. Open in **Unity (2021.3+ recommended)**

3. In the **Inspector** for the `MapGenerator` object:

   * Adjust noise parameters (scale, lacunarity, persistence, etc.)
   * Choose draw mode: **NoiseMap**, **ColorMap**, or **Mesh**
   * Enable **Auto Update** for real-time updates

4. Press **Generate** and use mouse clicks to select start and end points for pathfinding.

---

## 🧑‍🏫 Credits

This project was **inspired by and built upon** concepts taught by [Sebastian Lague](https://github.com/SebLague):

* [Procedural Landmass Generation](https://github.com/SebLague/Procedural-Landmass-Generation)
* [A* Pathfinding Project](https://github.com/SebLague/Pathfinding)

Huge thanks to Sebastian Lague for his exceptional educational content this project extends those tutorials by combining both systems and adding personalized features for academic and demonstration purposes.

---

## 📄 License

This project is released under the **MIT License**, following the license terms of the original repositories by Sebastian Lague.

---

## 📘 Author

**<Your Pratyush Soni>**
📧 Contact: [pratyushsoni1704@proton.me](mailto:pratyushsoni1704@proton.me)
💻 GitHub: [@whoami-pratyush]([https://github.com/your-username](https://github.com/whoami-pratyush))

---

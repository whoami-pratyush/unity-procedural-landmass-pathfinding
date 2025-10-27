I am developing a project about creating a **procedural terrain** and an **algorithm to pave a road from one desirable point to another**.

For this, I have researched and gained knowledge on the following topics:

---

### 🔷 **[[Perlin Noise Algorithm]]**

It's basically an algorithm that generates **organic-looking noise**, which we can turn into a **heatmap** or a **gradient map**. This algorithm not only helps in generating random but natural-looking terrain, it also helps make many different effects look **natural** in the field of computer graphics.

---

### 🔶 **New Perlin Noise Algorithm**

This is an improved version of the old Perlin Noise algorithm, optimized to overcome its shortcomings:

1. The old version **clumped values near the edges** of a quad, creating visible seams or patterns.
    
2. It was **unoptimized** due to a step that involved repeated multiplications. The new version fixes this so that finding a point in the quad requires only **additions and subtractions**.
    
3. The **interpolation equation** used to blend gradients had a **non-zero second derivative**, which caused small visual artifacts at the edges of cells. The new version reduces this issue for smoother results.

## 🌐 Sources :
https://en.wikipedia.org/wiki/Perlin_noise


##### 🏷️ Tags :
#CG/theory
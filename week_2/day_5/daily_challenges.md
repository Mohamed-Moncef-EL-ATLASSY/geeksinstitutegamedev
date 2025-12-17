## Quick Reflection
Question: Pick any real-life system (e.g., traffic, school, restaurant). Write 3 sentences describing how feedback loops might exist in it.

Answer:
- When a restaurant gets good reviews, more customers arrive, increasing wait times; long waits then trigger negative reviews, reducing demand later (balancing loop).
- High demand pushes management to hire more staff and optimize seating, which shortens waits and further improves reviews (reinforcing loop).
- Inventory usage drives reordering; if stock runs low, menu items sell out, reducing sales velocity and stabilizing demand until restocked (balancing loop).

---

## Identify Emergence
Question: Think of one unexpected behavior you’ve seen in a game (e.g., an exploit or creative solution). Explain briefly why it happened.

Answer:
- In Skyrim, placing a bucket over a shopkeeper’s head “blinds” them, letting players steal freely; this emerges from the NPC vision system relying on line-of-sight occlusion plus permissive collision/attachment logic.

---

## System Categorisation
Question: List 3 systems from different games and classify each as simple, complicated, or complex.

Answer:
- Tetris: simple (few rules, fully predictable outcomes).
- Dofus crafting weapons and gears: complicated (many parts, largely deterministic planning).
- Civilisation: complex (many interacting agents with unpredictable emergent behavior).

---

## Mini Diagram Sketch
Question: Choose any game system (e.g., health). Identify its source, stock, and sink in one short paragraph.

Answer:
- Source: Health pickups, healing items, regen over time, healer abilities, checkpoints (Unity: spawned via `Spawner` or drops from `OnDeath` events).
- Stock: Player `Health` value held by a `Health` component; UI bound via `Slider`/`Image.fillAmount`.
- Sink: Enemy hits, hazards, fall damage, DOT effects reducing `Health` in `OnTriggerEnter`/`Update`.

---

## Converter Thinking
Question: Name four resources that could be converted into something else in a crafting system (e.g., wood → plank).

Answer:
- Iron ores → Iron sword
- Herbs → Potion
- Animal hide → Leather
- Leather → Clothes

---

## Identify a Loop
Question: Pick a loop from any game (e.g., XP and leveling) and describe if it’s reinforcing or balancing.

Answer:
- Loop: XP → Level → Stats/Gear → Faster kills → More XP
- Type: Reinforcing
- Why: Each level increases damage, accelerating XP gain and progression.

---

## Design Fix
Question: Pick a loop from any game (e.g., XP and leveling) and describe if it’s reinforcing or balancing.

Answer:
- Loop: XP snowball in open-world ARPGs
- Type: Reinforcing
- Why: Prevents over-leveling trivializing content while preserving reward cadence; nudges players toward appropriately challenging encounters.

---

## System Connection Map
Question: Pick any game and describe how two of its systems influence each other (e.g., combat and economy).

Answer:
- System A: Combat (enemy drops, rune/XP awards, durability)
- System B: Economy (shops, crafting costs, repairs)
- Influence: Combat yields currency/materials that unlock gear and consumables; better gear increases combat efficiency, which increases drops and currency flow—tempered by repair costs and consumable spend.

---

## Emergence Exemple
Question: Describe a surprising or unintended behavior you’ve seen in a game and what systems likely caused it.

Answer:
- In Breath of the Wild, players chain electricity across the environment using metal weapons and dropped items to solve puzzles “incorrectly.” This emerges from systemic physics, conductivity tags on materials, and permissive puzzle validation that accepts any state meeting the electrical circuit condition.


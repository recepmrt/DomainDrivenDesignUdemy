## Tactical Design Patterns

### Entities
Unique and modifiable objects.

### Value Objects
Objects that lack identity and are generally immutable

### Aggregates
A group managed by an aggregate root that contains one or more entities and value objects

#### Aggregates and Aggregate Root — Order

- Aggregate: a consistency boundary that groups related entities and value objects. Changes that must be consistent are performed through the aggregate root.
- Aggregate Root: the only object that external code and repositories should directly reference or persist.

Order as an aggregate root
- `Order` is implemented as the aggregate root. It owns `OrderLine` entities and enforces invariants and business rules for the whole aggregate.
- `OrderLine` is an entity inside the Order aggregate (has its own identity, but no external lifecycle). `Money` is a value object (immutable, represents amount + currency).

Key responsibilities shown in the code
- Encapsulation: `Order` exposes behavior (`CreateOrder`, `RemoveOrderLine`) rather than letting callers manipulate `OrderLines` directly. This enforces rules in one place.
- Invariants:
    - Quantity validation (no order line with quantity < 1) is enforced inside `CreateOrder`.
    - Removing a non-existent `OrderLine` throws an exception — the root validates operations.
- Identity & consistency: `Order` supplies its `Id` when creating `OrderLine` so each child is tied to the aggregate root.

Practical recommendations
- Initialize collections in the aggregate root constructor (e.g. `OrderLines = new List<OrderLine>();`) to avoid null reference issues.
- Repositories should load and persist only the aggregate root (`Order`). Clients should not load or modify `OrderLine` independently.
- Use a transactional boundary or unit-of-work when persisting an aggregate to guarantee consistency across the aggregate.
- Consider domain events for cross-cutting concerns (e.g. `OrderCreated`, `OrderLineRemoved`) instead of coupling infrastructure logic into the entity.

Why this matters
- Enforcing invariants in the aggregate root reduces bugs and keeps business rules central.
- Treating `Order` as the single entry point for changes keeps the model consistent and easier to reason about when implementing persistence and business rules.

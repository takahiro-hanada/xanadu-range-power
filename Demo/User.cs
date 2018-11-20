using System;

namespace Demo
{
    class User
    {
        public Guid Id { get; } = Guid.NewGuid();

        public string Name { get; set; }

        public bool IsCrazy { get; set; }
    }
}

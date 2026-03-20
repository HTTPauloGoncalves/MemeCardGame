using System;
using System.Collections.Generic;
using System.Text;

namespace MemeCardGame.Domain.Entities
{
    public class Player
    {
        public Guid UserId { get; private set; }
        public int Hp { get; private set; }
        public int Mana { get; private set; }
        public int MaxMana { get; private set; }
        public List<Card> Deck { get; private set; }
        public List<Card> Hand { get; private set; }
        public List<Card> Field { get; private set; }

        private Player() { }

        public static Player Create(Guid userId, List<Card> deck)
        {
            return new Player
            {
                UserId = userId,
                Hp = 20,
                Mana = 3,
                MaxMana = 3,
                Deck = Shuffle(deck),
                Hand = new List<Card>(),
                Field = new List<Card>()
            };
        }
        private static List<Card> Shuffle(List<Card> deck)
        {
            var list = deck.ToList();
            var random = Random.Shared;

            for (int i = list.Count - 1; i > 0; i--)
            {
                int j = random.Next(i + 1);
                (list[i], list[j]) = (list[j], list[i]);
            }

            return list;
        }
    }
}

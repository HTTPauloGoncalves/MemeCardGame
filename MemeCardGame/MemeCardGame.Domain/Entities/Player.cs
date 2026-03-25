using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace MemeCardGame.Domain.Entities
{
    public class Player
    {
        public Guid UserId { get; private set; }

        [Range(0, 60, ErrorMessage = "O valor de HP tem que estar entre 0 a 60")]
        public int Hp { get; private set; }

        [Range(0, 40, ErrorMessage = "O valor de Mana tem que estar entre 0 a 40")]
        public int Followers { get; private set; }

        [Range(0, 40, ErrorMessage = "O valor de Mana tem que estar entre 0 a 40")]
        public int MaxFollowers { get; private set; }
        public List<Card> Deck { get; private set; } = new List<Card>();
        public List<Card> Hand { get; private set; } = new List<Card>();
        public List<Card> Field { get; private set; } = new List<Card>();

        public static Player Create(Guid userId, List<Card> deck)
        {
            return new Player
            {
                UserId = userId,
                Hp = 20,
                Followers = 3,
                MaxFollowers = 40,
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

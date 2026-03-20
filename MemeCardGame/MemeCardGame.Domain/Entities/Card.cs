using MemeCardGame.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace MemeCardGame.Domain.Entities
{
    public class Card
    {
        public Guid Id { get; private set; }
        public string Name { get; private set; }
        public string MemeDescription { get; private set; }
        public int FollowersCost { get; private set; }
        public CardType Type { get; private set; }
        public int Defense { get; private set; }
        public int Attack { get; private set; }
        public string ImageUrl { get; private set; }
        public Rarity Rarity { get; private set; }
        public string Effect { get; private set; }
        public string MemePhrase { get; private set; }


        private Card() { }

        public static Card Create(
            string name,
            string memeDescription,
            string memePhrase,
            int followersCost,
            CardType type,
            Rarity rarity,
            string effect,
            int attack,
            int defense,
            string imageUrl)
        {
            return new Card
            {
                Id = Guid.NewGuid(),
                Name = name,
                MemeDescription = memeDescription,
                MemePhrase = memePhrase,
                FollowersCost = followersCost,
                Type = type,
                Rarity = rarity,
                Effect = effect,
                Attack = attack,
                Defense = defense,
                ImageUrl = imageUrl
            };
        }
    }
    
}

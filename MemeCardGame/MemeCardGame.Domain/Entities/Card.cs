using MemeCardGame.Domain.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace MemeCardGame.Domain.Entities
{
    public class Card
    {
        public Guid Id { get; private set; }

        public string Name { get; private set; }

        public string MemeDescription { get; private set; }

        [Range(0, 20, ErrorMessage = "O custo de seguidores tem que estar entre 0 a 20")]
        public int FollowersCost { get; private set; }

        public CardType Type { get; private set; }

        [Range(0, 40, ErrorMessage = "O valor de defesa tem que estar entre 0 a 20")]
        public int Defense { get; private set; }

        [Range(0, 40, ErrorMessage = "O valor de ataque tem que estar entre 0 a 20")]
        public int Attack { get; private set; }

        public string ImageUrl { get; private set; }

        public Rarity Rarity { get; private set; }

        public string Effect { get; private set; }

        public string MemePhrase { get; private set; }


        #pragma warning disable CS8618 
        private Card() { } // Ef Core precisa de um construtor sem parâmetros para materializar a entidade, mas não queremos que ele seja usado diretamente.
        #pragma warning restore CS8618 

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

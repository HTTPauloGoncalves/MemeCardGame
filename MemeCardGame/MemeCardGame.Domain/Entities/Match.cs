using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace MemeCardGame.Domain.Entities
{
    public class Match
    {
        public Guid Id { get; private set; }
        public Guid PlayerOneId { get; private set; }
        public Guid PlayerTwoId { get; private set; }
        public Guid? Winner { get; private set; }

        [Range(0, 60, ErrorMessage = "O valor de HP tem que estar entre 0 a 60")]
        public int PlayerOneHp { get; private set; }

        [Range(0, 60, ErrorMessage = "O valor de HP tem que estar entre 0 a 60")]
        public int PlayerTwoHp { get; private set; }

        [Range(1, int.MaxValue, ErrorMessage = "O número total de turnos deve ser pelo menos 1")]
        public int TotalTurns { get; private set; }

        public DateTime FinishedAt { get; private set; }
        public DateTime StartedAt { get; private set; }

        public User PlayerOne { get; private set; }
        public User PlayerTwo { get; private set; }

        #pragma warning disable CS8618 
        private Match() { } // Ef Core precisa de um construtor sem parâmetros para materializar a entidade, mas não queremos que ele seja usado diretamente.
        #pragma warning restore CS8618 

        public void FinishMatch(Guid winnerId, Guid playerOneId, Guid playerTwoId, int playerOneHp, int playerTwoHp, int totalTurns, DateTime startedAt)
        {
            Winner = winnerId;
            PlayerOneId = playerOneId;
            PlayerTwoId = playerTwoId;
            PlayerOneHp = playerOneHp;
            PlayerTwoHp = playerTwoHp;
            TotalTurns = totalTurns;
            StartedAt = startedAt;
            FinishedAt = DateTime.UtcNow;
        }

    }
}

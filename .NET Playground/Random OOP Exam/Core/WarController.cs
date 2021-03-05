using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using Microsoft.CSharp.RuntimeBinder;
using WarCroft.Constants;
using WarCroft.Entities.Characters;
using WarCroft.Entities.Characters.Contracts;
using WarCroft.Entities.Items;

namespace WarCroft.Core
{
	public class WarController
    {
        private List<Character> _party;
        private Queue<Item> _items;

		public WarController()
        {
            this._party = new List<Character>();
            this._items = new Queue<Item>();
        }

		public string JoinParty(string[] args)
        {
            var characterType = args[0];
            var name = args[1];

            Character character = characterType switch
            {
				nameof(Warrior) => new Warrior(name),
				nameof(Priest) => new Priest(name),
				_ => null
            };

            if (character == null)
            {
                throw new ArgumentException(string.Format(ExceptionMessages.InvalidCharacterType, name));
            }

			this._party.Add(character);
            return string.Format(SuccessMessages.JoinParty, name);
        }

		public string AddItemToPool(string[] args)
		{
            var itemName = args[0];

            Item item = itemName switch
            {
                nameof(HealthPotion) => new HealthPotion(),
                nameof(FirePotion) => new FirePotion(),
                _ => null
            };

            if (item == null)
            {
                throw new ArgumentException(string.Format(ExceptionMessages.InvalidItem, itemName));
            }

            this._items.Enqueue(item);
            return string.Format(SuccessMessages.AddItemToPool, itemName);
		}

		public string PickUpItem(string[] args)
        {
            var characterName = args[0];
            var character = this._party.FirstOrDefault(x => x.Name == characterName);

            if (character == null)
            {
                throw new ArgumentException(string.Format(ExceptionMessages.CharacterNotInParty, characterName));
            }

            if (!this._items.Any())
            {
                throw new InvalidOperationException(ExceptionMessages.ItemPoolEmpty);
            }

            var item = this._items.Dequeue();
            character.Bag.AddItem(item);

            return string.Format(SuccessMessages.PickUpItem, character.Name, nameof(item));
        }

		public string UseItem(string[] args)
        {
            var characterName = args[0];
            var itemName = args[1];

            var character = this._party.FirstOrDefault(x => x.Name == characterName);

            if (character == null)
            {
                throw new ArgumentException(string.Format(ExceptionMessages.CharacterNotInParty, characterName));
            }

            var item = character.Bag.GetItem(itemName);
            character.UseItem(item);

            return string.Format(SuccessMessages.UsedItem, character.Name, nameof(item));
        }

        public string GetStats()
        {
            var sb = new StringBuilder();

            foreach (var character in this._party.OrderByDescending(x => x.IsAlive).ThenByDescending(x => x.Health))
            {
                sb.AppendLine(character.ToString());
            }

            return sb.ToString().Trim();
        }

		public string Attack(string[] args)
        {
            var sb = new StringBuilder();
            var attackerName = args[0];
            var receiverName = args[1];

            var attacker = (Warrior)this._party.FirstOrDefault(x => x.Name == attackerName);

            if (attacker == null)
            {
                throw new ArgumentException(string.Format(ExceptionMessages.CharacterNotInParty, attackerName));
            }

            var receiver = this._party.FirstOrDefault(x => x.Name == receiverName);

            if (receiver == null)
            {
                throw new ArgumentException(string.Format(ExceptionMessages.CharacterNotInParty, receiverName));
            }

            if (attacker.GetType() != typeof(Warrior))
            {
                throw new ArgumentException(string.Format(ExceptionMessages.AttackFail, attacker.Name));
            }

            attacker.Attack(receiver);

            sb.AppendLine(string.Format(SuccessMessages.AttackCharacter, attacker.Name, receiver.Name,
                attacker.AbilityPoints, receiver.Name, receiver.Health, receiver.BaseHealth, receiver.Armor,
                receiver.BaseArmor));

            if (!receiver.IsAlive)
            {
                sb.AppendLine(string.Format(SuccessMessages.AttackKillsCharacter, receiver.Name));
            }
            
            return sb.ToString().Trim();
        }

		public string Heal(string[] args)
        {
            var healerName = args[0];
            var healingReceiverName = args[1];

            var healer = (Priest)this._party.FirstOrDefault(x => x.Name == healerName);
            if (healer == null)
            {
                throw new ArgumentException(string.Format(ExceptionMessages.CharacterNotInParty, healerName));
            }

            var healingReceiver = this._party.FirstOrDefault(x => x.Name == healingReceiverName);
            if (healingReceiver == null)
            {
                throw new ArgumentException(string.Format(ExceptionMessages.CharacterNotInParty, healingReceiver));
            }

            if (healer.GetType() != typeof(Priest))
            {
                throw new ArgumentException(string.Format(ExceptionMessages.HealerCannotHeal, healerName));
            }

            healer.Heal(healingReceiver);

            return string.Format(SuccessMessages.HealCharacter, healer.Name, healingReceiver.Name, healer.AbilityPoints,
                healingReceiver.Name, healingReceiver.Health);
        }
	}
}

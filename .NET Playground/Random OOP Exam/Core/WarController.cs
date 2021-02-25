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
            return $"{name} joined the party!";
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
            return $"{itemName} added to pool.";
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

            return $"{characterName} picked up {nameof(item)}!";
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

            return $"{character.Name} used {itemName}.";
        }

        public string GetStats()
        {
            var sb = new StringBuilder();

            foreach (var character in this._party)
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

            sb.AppendLine(
                $"{attacker.Name} attacks {receiver.Name} for {attacker.AbilityPoints} hit points! {receiver.Name} " +
                $"has {receiver.Health}/{receiver.BaseHealth} HP and {receiver.Armor}/{receiver.BaseArmor} AP left!");

            if (!receiver.IsAlive)
            {
                sb.AppendLine($"{receiver.Name} is dead!");
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

            return $"{healer.Name} heals {healingReceiver.Name} for {healer.AbilityPoints}! {healingReceiver.Name} has {healingReceiver.Health} health now!";
        }
	}
}

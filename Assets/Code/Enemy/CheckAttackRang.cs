﻿using UnityEngine;

namespace Code.Enemy
{
    public class CheckAttackRang : MonoBehaviour
    {
        public EnemyMeleeAttack Attack;
        public TriggerObserver TriggerObserver;

        private void Start()
        {
            TriggerObserver.TriggerEnter += TriggerEnter;
            TriggerObserver.TriggerExit += TriggerExit;

            Attack.DisableAttack();
        }

        private void TriggerExit(Collider obj)
        {
            Attack.DisableAttack();
        }

        private void TriggerEnter(Collider obj)
        {
            Attack.EnableAttack();
        }
    }
}
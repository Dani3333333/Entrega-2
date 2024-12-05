using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponIK : MonoBehaviour
{
    public Animator animator;

    public Transform rightHandTarget; // Transform del WeaponSlot o el punto donde la mano derecha debe estar
    public Transform leftHandTarget;  // Transform para la mano izquierda (para sostener el arma con ambas manos)

    private bool apuntando;

    void Update()
    {
        // Determina si estamos apuntando (puedes cambiar esta lógica según tu implementación)
        apuntando = animator.GetBool("apuntar");
    }

    private void OnAnimatorIK(int layerIndex)
    {
        if (animator)
        {
            // Si está apuntando, usar IK para ajustar las manos
            if (apuntando)
            {
                // Ajustar mano derecha
                animator.SetIKPositionWeight(AvatarIKGoal.RightHand, 1.0f);
                animator.SetIKRotationWeight(AvatarIKGoal.RightHand, 1.0f);
                animator.SetIKPosition(AvatarIKGoal.RightHand, rightHandTarget.position);
                animator.SetIKRotation(AvatarIKGoal.RightHand, rightHandTarget.rotation);

                // Ajustar mano izquierda (si es un arma de dos manos)
                if (leftHandTarget != null)
                {
                    animator.SetIKPositionWeight(AvatarIKGoal.LeftHand, 1.0f);
                    animator.SetIKRotationWeight(AvatarIKGoal.LeftHand, 1.0f);
                    animator.SetIKPosition(AvatarIKGoal.LeftHand, leftHandTarget.position);
                    animator.SetIKRotation(AvatarIKGoal.LeftHand, leftHandTarget.rotation);
                }
            }
            else
            {
                // Si no está apuntando, desactiva el IK para las manos
                animator.SetIKPositionWeight(AvatarIKGoal.RightHand, 0);
                animator.SetIKRotationWeight(AvatarIKGoal.RightHand, 0);

                animator.SetIKPositionWeight(AvatarIKGoal.LeftHand, 0);
                animator.SetIKRotationWeight(AvatarIKGoal.LeftHand, 0);
            }
        }
    }
}

